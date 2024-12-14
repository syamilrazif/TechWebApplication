using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace WebApplication3
{
    public partial class _Default : Page
    {
        // This will store the conversion history
        private static List<ConversionRecord> conversionHistory = new List<ConversionRecord>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvHistory.DataSource = conversionHistory;
                gvHistory.DataBind();
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            string inputData = txtNumber.Text;

            if(string.IsNullOrEmpty(lblResult.Text))
            {
                lblResult.Text = "";
            }
            

            if(decimal.TryParse(inputData, out decimal number))
            {
                string result = ConvertTowords(number);
                lblResult.Text = result;

                //Try to add to history
                conversionHistory.Add(new ConversionRecord { Number = number, Words = result });
                gvHistory.DataSource = conversionHistory;
                gvHistory.DataBind();

            }
            else
            {
                lblResult.Text = "Invalid number !!";
            }

        }

        private string ConvertTowords(decimal number)
        {
            //return NumberChangetoWords((int)number) + (number % 1 > 0 ? " AND " + (number % 1).ToString("0.00").Split('.')[1] + " CENTS" : "");


            if (number == 0)
                return "Zero Ringgit";

            int ringgit = (int)Math.Floor(number);
            int sen = (int)((number - ringgit) * 100);

            string words = NumberChangetoWords(ringgit) + " ringgit ";

            if (sen > 0)
            {
                words += " and " + NumberChangetoWords(sen) + " sen ";

            }

            return words.ToUpper();
        }

        private string NumberChangetoWords(int number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "minus " + NumberChangetoWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += NumberChangetoWords(number / 1000000000) + " billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberChangetoWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberChangetoWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberChangetoWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var numUnitMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                var numTenMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                if (number < 20)
                    words += numUnitMap[number];
                else
                {
                    words += numTenMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + numUnitMap[number % 10];

                }

            }

            return words.Trim();

        }

        public class ConversionRecord
        {
            public decimal Number { get; set; }
            public string Words { get; set; }
        }
    }
}