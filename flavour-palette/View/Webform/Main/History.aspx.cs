using flavour_palette.Model;
using flavour_palette.Order_Management.Order_History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flavour_palette.View.Webform.Main
{
    public partial class History : System.Web.UI.Page
    {
        private OrderController oc = new OrderController();
        public List<Object> headerWithFood = new List<Object>();
        public List<Object> uniqueTransactions = new List<Object>();
        public int userId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            userId = (int)HttpContext.Current.Session["userId"];
            headerWithFood = oc.fetchAllWithFood(userId);
            uniqueTransactions = headerWithFood.GroupBy(t => t.GetType().GetProperty("TransactionID").GetValue(t, null))
                                              .Select(group => group.First())
                                              .ToList();

            headerRepeater.DataSource = uniqueTransactions;
            headerRepeater.DataBind();
        }
    }
}