using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Ado.net
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            //string connectionString = "Data Source = SRV2\PUPILS; Initial Catalog = api_ado; Integrated Security = True; Trust Server Certificate = True";
            string connectionString = "data source=srv2\\pupils;initial catalog=api_ado;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";

            DataAccess dataAccess = new DataAccess();
       
            //add category 
            dataAccess.AddCategory(connectionString);
            DialogResult answerOfCategory = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            while (answerOfCategory == DialogResult.Yes)
            {
                dataAccess.AddCategory(connectionString);
                answerOfCategory = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            }
            //add Product 
            dataAccess.AddProduct(connectionString);
            DialogResult answerOfProduct = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            while (answerOfProduct == DialogResult.Yes)
            {
                dataAccess.AddProduct(connectionString);
                answerOfProduct = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            }
            //get products
            dataAccess.getAllProduct(connectionString);
            //get category
            dataAccess.getAllCategory(connectionString);

        }
    }
}
