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
    public partial class DetailPage : System.Web.UI.Page
    {
        private OrderController oc = new OrderController();
        public List<TransactionDetail> trdetail = new List<TransactionDetail>();
        public TransactionHeader trHeader = new TransactionHeader();
        protected void Page_Load(object sender, EventArgs e)
        {
            int trId = Convert.ToInt32(Request.QueryString["TransactionId"].ToString());
            trdetail = oc.getTrDetail(trId);
            trHeader = oc.search(trId);

            detailRepeater.DataSource = trdetail;
            detailRepeater.DataBind();
        }
    }
}