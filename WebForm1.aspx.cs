using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace teste_repeater
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<compra> compras = new List<compra>();
        public List<compraItem> comprasItens = new List<compraItem>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                compras.Add(new compra(1, "marcos", 10));
                compras.Add(new compra(2, "pedro", 32));
                compras.Add(new compra(3, "chico", 59));

                comprasItens.Add(new compraItem(1, 1, "chinelo"));
                comprasItens.Add(new compraItem(2, 3, "chocolate"));
                comprasItens.Add(new compraItem(3, 3, "leite"));
                comprasItens.Add(new compraItem(4, 3, "cafe"));
                comprasItens.Add(new compraItem(5, 2, "arroz"));
                comprasItens.Add(new compraItem(6, 2, "maminha"));

                Repeater1.DataSource = compras;
                Repeater1.DataBind();

            }


        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;

            if (e.Item.Controls.Contains((Repeater)e.Item.FindControl("Repeater2")))
            {
                Repeater repeater2 = (Repeater)e.Item.FindControl("Repeater2");
                repeater2.DataSource = comprasItens.Where(t => t.idCompra == ((compra)e.Item.DataItem).id);
                repeater2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Root listaItens = new Root();
            List<Item> items = new List<Item>();

            for (var i = 0; i < Repeater1.Items.Count; i++)
            {
                var x = ((System.Web.UI.WebControls.Button)Repeater1.Items[i].FindControl("Button1")).CommandArgument;

                if (x == (((System.Web.UI.WebControls.Button)sender).CommandArgument))
                {
                    Repeater repeater2 = (Repeater)Repeater1.Items[i].FindControl("Repeater2");

                    for (int j = 0; j < repeater2.Items.Count; j++)
                    {
                        HiddenField HiddenField1 = (HiddenField)repeater2.Items[j].FindControl("HiddenField1");
                        HiddenField HiddenField2 = (HiddenField)repeater2.Items[j].FindControl("HiddenField2");

                        CheckBox CheckBox1 = (CheckBox)repeater2.Items[j].FindControl("CheckBox1");

                        Item item = new Item(HiddenField1.Value, Convert.ToInt32(HiddenField2.Value), CheckBox1.Checked ? "APPROVED" : "REFUSED");

                        items.Add(item);
                    }
                }
            }

            listaItens.items = items;
        }
    }

    public class compra
    {
        public compra(int id, string comprador, double valor)
        {
            this.id = id;
            this.comprador = comprador;
            this.valor = valor;
        }
        public int id { get; set; }
        public string comprador { get; set; }
        public double valor { get; set; }
    }

    public class compraItem
    {
        public compraItem(int id, int idCompra, string nome)
        {
            this.id = id;
            this.idCompra = idCompra;
            this.nomeItem = nome;
        }
        public int id { get; set; }
        public int idCompra { get; set; }
        public string nomeItem { get; set; }
    }

    public class Root
    {
        public List<Item> items { get; set; }
    }

    public class Item
    {
        public Item(string id, int installment, string status)
        {
            this.id = id;
            this.installment = installment;
            this.status = status;
        }

        public string id { get; set; }
        public int installment { get; set; }
        public string status { get; set; }

    }
}