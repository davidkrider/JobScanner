using System;
using System.Windows.Forms;
using System.Threading;
using CoreScanner;
using System.Diagnostics;
using System.Xml;
using System.Net;
using System.Text.RegularExpressions;


namespace JobScanner
{
    public partial class FormJobScanner : Form
    {
        CCoreScannerClass m_pCoreScanner;

        // Scanner types
        public const short SCANNER_TYPES_ALL = 1;
        public const short SCANNER_TYPES_SNAPI = 2;
        public const short SCANNER_TYPES_SSI = 3;
        public const short SCANNER_TYPES_RSM = 4;
        public const short SCANNER_TYPES_IMAGING = 5;
        public const short SCANNER_TYPES_IBMHID = 6;
        public const short SCANNER_TYPES_NIXMODB = 7;
        public const short SCANNER_TYPES_HIDKB = 8;
        public const short SCANNER_TYPES_IBMTT = 9;
        public const short SCALE_TYPES_IBM = 10;


        public FormJobScanner()
        {
            InitializeComponent();

            try
            {
                m_pCoreScanner = new CoreScanner.CCoreScannerClass();
            }
            catch (Exception)
            {
                Thread.Sleep(1000);
                m_pCoreScanner = new CoreScanner.CCoreScannerClass();
            }

            int status = 1;
            short[] m_arScannerTypes = new short[1];
            m_arScannerTypes[0] = 1;
            short m_nNumberOfTypes = 1;
            m_pCoreScanner.Open(0, m_arScannerTypes, m_nNumberOfTypes, out status);

            m_pCoreScanner.BarcodeEvent += new _ICoreScannerEvents_BarcodeEventEventHandler(OnBarcodeEvent);

            string inXml = "<inArgs>" +
                            "<cmdArgs>" +
                            "<arg-int>6</arg-int>" +
                            "<arg-int>1,2,4,8,16,32</arg-int>" +
                            "</cmdArgs>" +
                            "</inArgs>";
            string outXml = "";
            status = 1;
            m_pCoreScanner.ExecCommand(1001, ref inXml, out outXml, out status);
            Debug.Print(" *** Status: " + status.ToString());

        }

        void OnBarcodeEvent(short eventType, ref string scanData)
        {
            try
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(scanData);
                string barcode = xmlDoc.DocumentElement.GetElementsByTagName("datalabel").Item(0).InnerText;

                string strData = String.Empty;
                string[] numbers = barcode.Split(' ');
                foreach (string number in numbers)
                {
                    if (String.IsNullOrEmpty(number))
                    {
                        break;
                    }
                    strData += ((char)Convert.ToInt32(number, 16)).ToString();
                }

                if (Regex.IsMatch(strData, @"\d+-\d+"))
                {
                    textBoxItem.Invoke(new MethodInvoker(delegate
                    {
                        textBoxItem.Clear();
                        textBoxItem.Text = strData;
                    }));
                }
                else if (Regex.IsMatch(strData, @"\d{12}"))
                {
                    textBoxLot.Invoke(new MethodInvoker(delegate
                    {
                        textBoxLot.Clear();
                        textBoxLot.Text = strData;
                    }));
                }
                else
                {
                    textBoxQuantity.Invoke(new MethodInvoker(delegate
                    {
                        textBoxQuantity.Clear();
                        textBoxQuantity.Text = strData;
                    }));
                }

                if (!String.IsNullOrEmpty(textBoxVim.Text) && !String.IsNullOrEmpty(textBoxEmployee.Text) &&
                    !String.IsNullOrEmpty(textBoxLot.Text) && !String.IsNullOrEmpty(textBoxQuantity.Text) &&
                    !String.IsNullOrEmpty(textBoxItem.Text))
                {
                    postJob(textBoxVim.Text, textBoxEmployee.Text, textBoxLot.Text,
                        textBoxItem.Text, textBoxQuantity.Text);
                    textBoxVim.Clear();
                    textBoxEmployee.Clear();
                    textBoxLot.Clear();
                    textBoxQuantity.Clear();
                    textBoxItem.Clear();
                }

            }
            catch (Exception)
            {
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {

            postJob(textBoxVim.Text, textBoxEmployee.Text, textBoxLot.Text, 
                textBoxItem.Text, textBoxQuantity.Text);

        }


        private void postJob(string vim, string employee, string lot, string item, string quantity)
        {
            using (WebClient client = new WebClient())
            {

                client.Headers.Add("Content-Type", "application/json");
                try
                {
                    Job j = new Job();
                    if (String.IsNullOrEmpty(vim))
                    {
                        j.Vim = 1;
                    }
                    else
                    {
                        j.Vim = Convert.ToInt32(vim);
                    }
                    if (String.IsNullOrEmpty(employee))
                    {
                        j.Employee = 1;
                    }
                    else
                    {
                        j.Employee = Convert.ToInt32(employee);
                    }
                    if (String.IsNullOrEmpty(lot))
                    {
                        j.Lot = 160118000601;
                    }
                    else
                    {
                        j.Lot = Convert.ToInt64(lot);
                    }
                    if (String.IsNullOrEmpty(item))
                    {
                        j.Item = "100-01";
                    }
                    else
                    {
                        j.Item = item;
                    }
                    if (String.IsNullOrEmpty(quantity))
                    {
                        j.Quantity = 137425;
                    }
                    else
                    {
                        j.Quantity = Convert.ToInt32(quantity);
                    }
                    string data = @"{" +
                        @"""vim_id"":" + j.Vim + "," +
                        @"""employee"":{""badge_number"":" + j.Employee + "}," +
                        @"""lot"":{""designation"":" + j.Lot + "}," +
                        @"""product"":{""designation"":""" + j.Item + @"""}," +
                        @"""quantity"":" + j.Quantity + "}";
                    Debug.Print(data);
                    string response = client.UploadString("http://192.168.10.23:3000/jobs", "POST", data);
                    Debug.Print(response);
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                }
            }
        }

    }


    public class Job
    {
        private int _vim;
        private int _employee;
        private Int64 _lot;
        private string _item;
        private int _quantity;

        public int Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        public int Vim
        {
            get { return _vim; }
            set { _vim = value; }
        }

        public Int64 Lot
        {
            get { return _lot; }
            set { _lot = value; }
        }

        public string Item
        {
            get { return _item; }
            set { _item = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

    }

}
