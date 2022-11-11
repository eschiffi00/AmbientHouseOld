using DomainAmbientHouse.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;


namespace DomainAmbientHouse.Servicios
{
    public class Pipedrive
    {

        public List<ClientesPipedrive> BuscarContactos(string contacto, string user)
        {

            Persons cliente;


            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://grupolahusen.pipedrive.com/v1/persons?user_id=" + user + "&name=" + contacto + "&visible_to=1&api_token=d063057f2a70f91619815dd9e7a4ec673d34b80f");


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                cliente = JsonConvert.DeserializeObject<Persons>(json);
            }

            List<ClientesPipedrive> Salida = new List<ClientesPipedrive>();

            if (cliente.data != null)
            {

                foreach (var item in cliente.data)
                {
                    ClientesPipedrive cliPipe = new ClientesPipedrive();

                    cliPipe.Id = item.id;
                    cliPipe.ApellidoNombre = item.name;
                    cliPipe.RazonSocial = item.org_name;

                    cliPipe.Identificador = item.name + " (" + (item.org_name == null ? "" : item.org_name) + ")";


                    Salida.Add(cliPipe);

                }
            }

            return Salida.ToList();


        }

        public List<ClientesPipedrive> ObtenerListaClientesPipedrive(string clientes, string user)
        {
            Persons cliente;

            //System.Net.WebRequest req = System.Net.WebRequest.Create(@"https://grupolahusen.pipedrive.com/v1/deals?title=strevezza&value=200000&currency=EUR&api_token=d49f1ad7e301dbe32c3da117ecf57d861e1a1941");

            //req.Method = "POST";

            String conexion = "https://grupolahusen.pipedrive.com/v1/persons?user_id=" + user + "&start=0&limit=100&api_token=d063057f2a70f91619815dd9e7a4ec673d34b80f";

            //public const SecurityProtocolType _Tls12 = (SecurityProtocolType)SslProtocols.Tls12;

            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://grupolahusen.pipedrive.com/v1/persons?user_id=" + user + "&start=0&limit=100&api_token=d063057f2a70f91619815dd9e7a4ec673d34b80f");

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                cliente = JsonConvert.DeserializeObject<Persons>(json);
            }

            List<ClientesPipedrive> Salida = new List<ClientesPipedrive>();

            if (cliente.data != null)
            {

                foreach (var item in cliente.data)
                {
                    ClientesPipedrive cliPipe = new ClientesPipedrive();

                    cliPipe.Id = item.id;
                    cliPipe.ApellidoNombre = item.name;
                    cliPipe.RazonSocial = item.org_name;

                    cliPipe.Identificador = item.name + " (" + (item.org_name == null ? "" : item.org_name) + ")";

                    Salida.Add(cliPipe);

                }
            }

            int star = 0;

            while (cliente.additional_data.pagination.more_items_in_collection)
            {
                star = star + 100;

                HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(@"https://grupolahusen.pipedrive.com/v1/persons?user_id=" + user + "&start=" + star.ToString() + "&limit=100&api_token=d063057f2a70f91619815dd9e7a4ec673d34b80f");

                using (HttpWebResponse response = (HttpWebResponse)request1.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    cliente = JsonConvert.DeserializeObject<Persons>(json);
                }

                if (cliente.data != null)
                {
                    foreach (var item in cliente.data)
                    {
                        ClientesPipedrive cliPipe = new ClientesPipedrive();

                        cliPipe.Id = item.id;
                        cliPipe.ApellidoNombre = item.name;
                        cliPipe.RazonSocial = item.org_name;

                        cliPipe.Identificador = item.name + " (" + (item.org_name == null ? "" : item.org_name) + ")";

                        Salida.Add(cliPipe);

                    }
                }

            }



            if (clientes != null)
            {
                return Salida.Where(o => o.ApellidoNombre.Contains(clientes)).ToList();
            }
            else
            {
                return Salida.ToList();
            }

        }

        public List<UsuariosPipedrive> ObtenerListaUsuariosPipedrive()
        {
            Users usuarios;


            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://grupolahusen.pipedrive.com/v1/users?api_token=d063057f2a70f91619815dd9e7a4ec673d34b80f");

            //https://grupolahusen.pipedrive.com/v1/persons?start=0&api_token=d49f1ad7e301dbe32c3da117ecf57d861e1a1941");

            //https://grupolahusen.pipedrive.com/v1/persons/5756?api_token=d49f1ad7e301dbe32c3da117ecf57d861e1a1941
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                usuarios = JsonConvert.DeserializeObject<Users>(json);



            }

            List<UsuariosPipedrive> Salida = new List<UsuariosPipedrive>();

            foreach (var item in usuarios.data)
            {
                UsuariosPipedrive usuPipe = new UsuariosPipedrive();

                usuPipe.Id = item.id;
                usuPipe.ApellidoNombre = item.name;

                usuPipe.Mail = item.email;



                Salida.Add(usuPipe);

            }

            return Salida.ToList();


        }

        public void GrabarPersona()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://grupolahusen.pipedrive.com/v1/persons?name=PEPE&visible_to=1&api_token=d49f1ad7e301dbe32c3da117ecf57d861e1a1941");


        }



        //public List<ClientesPrueba> ObtenerClientes(int usuario)
        //{
        //    ClientesPruebaNegocios negocios = new ClientesPruebaNegocios();

        //    return negocios.ObtenerClientes(usuario);
        //}

    }

    public class UsuariosPipedrive
    {
        public int Id { get; set; }
        public string ApellidoNombre { get; set; }
        public string Mail { get; set; }


    }

    //#region Personas
    //public class Datum
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //    public string email { get; set; }
    //    public string phone { get; set; }
    //    public int? org_id { get; set; }
    //    public string org_name { get; set; }
    //    public string visible_to { get; set; }
    //    public object picture { get; set; }
    //}

    //public class Pagination
    //{
    //    public int start { get; set; }
    //    public int limit { get; set; }
    //    public bool more_items_in_collection { get; set; }
    //    public int next_start { get; set; }
    //}

    //public class AdditionalData
    //{
    //    public string search_method { get; set; }
    //    public Pagination pagination { get; set; }
    //}

    //public class Persons
    //{
    //    public bool success { get; set; }
    //    public List<Datum> data { get; set; }
    //    public AdditionalData additional_data { get; set; }
    //}

    //#endregion

    #region Usuarios
    public class Usuarios
    {
        public int id { get; set; }
        public string name { get; set; }
        public string default_currency { get; set; }
        public string locale { get; set; }
        public int lang { get; set; }
        public string email { get; set; }
        public object phone { get; set; }
        public bool activated { get; set; }
        public string last_login { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public string signup_flow_variation { get; set; }
        public bool has_created_company { get; set; }
        public int is_admin { get; set; }
        public string timezone_name { get; set; }
        public string timezone_offset { get; set; }
        public bool active_flag { get; set; }
        public int role_id { get; set; }
        public string icon_url { get; set; }
        public bool is_you { get; set; }
    }

    public class AdditionalDataUsuarios
    {
        public int company_id { get; set; }
    }

    public class Users
    {
        public bool success { get; set; }
        public List<Usuarios> data { get; set; }
        public AdditionalDataUsuarios additional_data { get; set; }
    }

    #endregion


    public class OwnerId
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public bool has_pic { get; set; }
        public object pic_hash { get; set; }
        public bool active_flag { get; set; }
        public int value { get; set; }
    }

    public class OrgId
    {
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public string address { get; set; }
        public string cc_email { get; set; }
        public int value { get; set; }
    }

    public class Phone
    {
        public string label { get; set; }
        public string value { get; set; }
        public bool primary { get; set; }
    }

    public class Email
    {
        public string label { get; set; }
        public string value { get; set; }
        public bool primary { get; set; }
    }

    public class Im
    {
        public string value { get; set; }
        public bool primary { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public int company_id { get; set; }
        public OwnerId owner_id { get; set; }
        public OrgId org_id { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int open_deals_count { get; set; }
        public int related_open_deals_count { get; set; }
        public int closed_deals_count { get; set; }
        public int related_closed_deals_count { get; set; }
        public int participant_open_deals_count { get; set; }
        public int participant_closed_deals_count { get; set; }
        public int email_messages_count { get; set; }
        public int activities_count { get; set; }
        public int done_activities_count { get; set; }
        public int undone_activities_count { get; set; }
        public int reference_activities_count { get; set; }
        public int files_count { get; set; }
        public int notes_count { get; set; }
        public int followers_count { get; set; }
        public int won_deals_count { get; set; }
        public int related_won_deals_count { get; set; }
        public int lost_deals_count { get; set; }
        public int related_lost_deals_count { get; set; }
        public bool active_flag { get; set; }
        public List<Phone> phone { get; set; }
        public List<Email> email { get; set; }
        public string first_char { get; set; }
        public string update_time { get; set; }
        public string add_time { get; set; }
        public string visible_to { get; set; }
        public object picture_id { get; set; }
        public string next_activity_date { get; set; }
        public string next_activity_time { get; set; }
        public int? next_activity_id { get; set; }
        public int? last_activity_id { get; set; }
        public string last_activity_date { get; set; }
        public string timeline_last_activity_time { get; set; }
        public string timeline_last_activity_time_by_owner { get; set; }
        public string last_incoming_mail_time { get; set; }
        public string last_outgoing_mail_time { get; set; }
        public int? __invalid_name__06ad3389054ed91043dc8a6d589a16f375d3fbd2 { get; set; }
        public string __invalid_name__8b5f3231223c6454b5d789b57d82156fd47df6fd { get; set; }
        public List<Im> im { get; set; }
        public object postal_address { get; set; }
        public object postal_address_subpremise { get; set; }
        public object postal_address_street_number { get; set; }
        public object postal_address_route { get; set; }
        public object postal_address_sublocality { get; set; }
        public object postal_address_locality { get; set; }
        public object postal_address_admin_area_level_1 { get; set; }
        public object postal_address_admin_area_level_2 { get; set; }
        public object postal_address_country { get; set; }
        public object postal_address_postal_code { get; set; }
        public object postal_address_formatted_address { get; set; }
        public object efefe45d4b938d88804bc9a885a0c10fd9ef2eaf { get; set; }
        public string __invalid_name__6bfce7616a5eb0ee44d9f1cead42686225d75b6f { get; set; }
        public string org_name { get; set; }
        public string owner_name { get; set; }
        public string cc_email { get; set; }
    }

    public class Pagination
    {
        public int start { get; set; }
        public int limit { get; set; }
        public bool more_items_in_collection { get; set; }
    }

    public class AdditionalData
    {
        public Pagination pagination { get; set; }
    }

    public class __invalid_type__1635
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1637
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1634
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1636
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1638
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1639
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1640
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1641
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1642
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1643
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1645
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1644
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1646
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1647
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1649
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1648
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1650
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1652
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__2365
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1653
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1655
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1654
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1656
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1657
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1658
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1659
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1660
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1661
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1662
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1664
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1663
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1665
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1666
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1667
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1668
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1669
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1670
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1671
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1672
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1673
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1674
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__1675
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__2364
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public string address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__2366
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__2368
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__2393
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class __invalid_type__2719
    {
        public int id { get; set; }
        public string name { get; set; }
        public int people_count { get; set; }
        public int owner_id { get; set; }
        public object address { get; set; }
        public string cc_email { get; set; }
    }

    public class Organization
    {
        public __invalid_type__1635 __invalid_name__1635 { get; set; }
        public __invalid_type__1637 __invalid_name__1637 { get; set; }
        public __invalid_type__1634 __invalid_name__1634 { get; set; }
        public __invalid_type__1636 __invalid_name__1636 { get; set; }
        public __invalid_type__1638 __invalid_name__1638 { get; set; }
        public __invalid_type__1639 __invalid_name__1639 { get; set; }
        public __invalid_type__1640 __invalid_name__1640 { get; set; }
        public __invalid_type__1641 __invalid_name__1641 { get; set; }
        public __invalid_type__1642 __invalid_name__1642 { get; set; }
        public __invalid_type__1643 __invalid_name__1643 { get; set; }
        public __invalid_type__1645 __invalid_name__1645 { get; set; }
        public __invalid_type__1644 __invalid_name__1644 { get; set; }
        public __invalid_type__1646 __invalid_name__1646 { get; set; }
        public __invalid_type__1647 __invalid_name__1647 { get; set; }
        public __invalid_type__1649 __invalid_name__1649 { get; set; }
        public __invalid_type__1648 __invalid_name__1648 { get; set; }
        public __invalid_type__1650 __invalid_name__1650 { get; set; }
        public __invalid_type__1652 __invalid_name__1652 { get; set; }
        public __invalid_type__2365 __invalid_name__2365 { get; set; }
        public __invalid_type__1653 __invalid_name__1653 { get; set; }
        public __invalid_type__1655 __invalid_name__1655 { get; set; }
        public __invalid_type__1654 __invalid_name__1654 { get; set; }
        public __invalid_type__1656 __invalid_name__1656 { get; set; }
        public __invalid_type__1657 __invalid_name__1657 { get; set; }
        public __invalid_type__1658 __invalid_name__1658 { get; set; }
        public __invalid_type__1659 __invalid_name__1659 { get; set; }
        public __invalid_type__1660 __invalid_name__1660 { get; set; }
        public __invalid_type__1661 __invalid_name__1661 { get; set; }
        public __invalid_type__1662 __invalid_name__1662 { get; set; }
        public __invalid_type__1664 __invalid_name__1664 { get; set; }
        public __invalid_type__1663 __invalid_name__1663 { get; set; }
        public __invalid_type__1665 __invalid_name__1665 { get; set; }
        public __invalid_type__1666 __invalid_name__1666 { get; set; }
        public __invalid_type__1667 __invalid_name__1667 { get; set; }
        public __invalid_type__1668 __invalid_name__1668 { get; set; }
        public __invalid_type__1669 __invalid_name__1669 { get; set; }
        public __invalid_type__1670 __invalid_name__1670 { get; set; }
        public __invalid_type__1671 __invalid_name__1671 { get; set; }
        public __invalid_type__1672 __invalid_name__1672 { get; set; }
        public __invalid_type__1673 __invalid_name__1673 { get; set; }
        public __invalid_type__1674 __invalid_name__1674 { get; set; }
        public __invalid_type__1675 __invalid_name__1675 { get; set; }
        public __invalid_type__2364 __invalid_name__2364 { get; set; }
        public __invalid_type__2366 __invalid_name__2366 { get; set; }
        public __invalid_type__2368 __invalid_name__2368 { get; set; }
        public __invalid_type__2393 __invalid_name__2393 { get; set; }
        public __invalid_type__2719 __invalid_name__2719 { get; set; }
    }

    public class __invalid_type__2759856
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public bool has_pic { get; set; }
        public object pic_hash { get; set; }
        public bool active_flag { get; set; }
    }

    public class User
    {
        public __invalid_type__2759856 __invalid_name__2759856 { get; set; }
    }

    public class RelatedObjects
    {
        public Organization organization { get; set; }
        public User user { get; set; }
    }

    public class Persons
    {
        public bool success { get; set; }
        public List<Datum> data { get; set; }
        public AdditionalData additional_data { get; set; }
        public RelatedObjects related_objects { get; set; }
    }


}
