using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceCvoInventaris
{
    [ServiceContract]
    public interface ICvoInventarisService
    {
        #region CRUD TblAccount
        [OperationContract]
        Account AccountGetById(int id);

        [OperationContract]
        List<Account> AccountGetAll();

        [OperationContract]
        int AccountCreate(Account a);

        [OperationContract]
        bool AccountUpdate(Account a);

        [OperationContract]
        bool AccountDelete(int id);

        [OperationContract]
        bool AccountLogin(Account a);

        [OperationContract]
        Account AccountGetByEmail(string email);

        [OperationContract]
        bool AccountVerstuurWachtwoordResetEmail(string email);
        #endregion

        #region CRUD TblSession
        [OperationContract]
        Session SessionGetById(int id);

        [OperationContract]
        List<Session> SessionGetAll();

        [OperationContract]
        int SessionCreate(Session s);

        [OperationContract]
        bool SessionUpdate(Session s);

        [OperationContract]
        bool SessionDelete(int id);

        [OperationContract]
        bool SessionGetByAccount(Account a);
        #endregion

        #region CRUD TblTicketing
        [OperationContract]
        Ticket TicketingGetById(int id);

        [OperationContract]
        List<Ticket> TicketingGetAll();

        [OperationContract]
        int TicketingCreate(Ticket t);

        [OperationContract]
        bool TicketingUpdate(Ticket t);

        [OperationContract]
        bool TicketingDelete(int id);
        #endregion

        #region CRUD TblCpu
        [OperationContract]
        Cpu CpuGetById(int id);

        [OperationContract]
        List<Cpu> CpuGetAll();

        [OperationContract]
        int CpuCreate(Cpu c);

        [OperationContract]
        bool CpuUpdate(Cpu c);

        [OperationContract]
        bool CpuDelete(int id);
        #endregion

        [OperationContract]
        List<Cpu> RapporteringCpu(string s, string[] keuzeKolommen);

        #region CRUD TblDevice
        [OperationContract]
        Device DeviceGetById(int id);

        [OperationContract]
        List<Device> DeviceGetAll();

        [OperationContract]
        int DeviceCreate(Device d);

        [OperationContract]
        bool DeviceUpdate(Device d);

        [OperationContract]
        bool DeviceDelete(int id);
        #endregion
        [OperationContract]
        List<Device> RapporteringDevice(string s, string[] keuzeKolommen);

        #region CRUD TblGrafischeKaart
        [OperationContract]
        GrafischeKaart GrafischeKaartGetById(int id);

        [OperationContract]
        List<GrafischeKaart> GrafischeKaartGetAll();

        [OperationContract]
        int GrafischeKaartCreate(GrafischeKaart g);

        [OperationContract]
        bool GrafischeKaartUpdate(GrafischeKaart g);

        [OperationContract]
        bool GrafischeKaartDelete(int id);
        #endregion

        [OperationContract]
        List<GrafischeKaart> RapporteringGrafischeKaart(string s, string[] keuzeKolommen);

        #region CRUD TblInventaris
        [OperationContract]
        int InventarisCreate(Inventaris inventaris);
        [OperationContract]
        List<Inventaris> InventarisGetAll();
        [OperationContract]
        Inventaris InventarisGetById(int id);
        [OperationContract]
        bool InventarisUpdate(Inventaris inventaris);
        [OperationContract]
        bool InventarisDelete(int id);
        #endregion

        #region CRUD TblObject
        [OperationContract]
        int ObjectCreate(Object Object);
        [OperationContract]
        List<Object> ObjectGetAll();
        [OperationContract]
        Object ObjectGetById(int id);
        [OperationContract]
        bool ObjectUpdate(Object Object);
        [OperationContract]
        bool ObjectDelete(int id);
        #endregion

        #region CRUD TblNetwerk
        [OperationContract]
        int NetwerkCreate(Netwerk Netwerk);
        [OperationContract]
        List<Netwerk> NetwerkGetAll();
        [OperationContract]
        Netwerk NetwerkGetById(int Id);
        [OperationContract]
        bool NetwerkUpdate(Netwerk Netwerk);
        [OperationContract]
        bool NetwerkDelete(int Id);
        #endregion

        [OperationContract]
        List<Netwerk> RapporteringNetwerk(string s, string[] keuzeKolommen);


        #region CRUD TblVerzekering
        [OperationContract]
        int VerzekeringCreate(Verzekering verzekering);

        [OperationContract]
        bool VerzekeringDelete(int id);

        [OperationContract]
        List<Verzekering> VerzekeringGetAll();

        [OperationContract]
        Verzekering VerzekeringGetById(int id);

        [OperationContract]
        bool VerzekeringUpdate(Verzekering verzekering);
        #endregion

        #region CRUD TblObjectType
        [OperationContract]
        int ObjectTypeCreate(ObjectTypes objectType);

        [OperationContract]
        ObjectTypes ObjectTypeGetById(int id);

        [OperationContract]
        List<ObjectTypes> ObjectTypeGetAll();

        [OperationContract]
        bool ObjectTypeDelete(int id);

        [OperationContract]
        bool ObjectTypeUpdate(ObjectTypes objectType);
        #endregion

        #region CRUD TblHardware
        [OperationContract]
        int HardwareCreate(Hardware hardware);

        [OperationContract]
        Hardware HardwareGetById(int id);

        [OperationContract]
        List<Hardware> HardwareGetAll();

        [OperationContract]
        bool HardwareUpdate(Hardware hardware);

        [OperationContract]
        bool HardwareDelete(int id);
        #endregion
        [OperationContract]
        List<Hardware> RapporteringHardware(string s, string[] keuzeKolommen);

        #region CRUD TblHarddisk
        [OperationContract]
        List<Harddisk> HarddiskGetAll();

        [OperationContract]
        Harddisk HarddiskGetById(int id);

        [OperationContract]
        int HarddiskCreate(Harddisk h);

        [OperationContract]
        bool HarddiskUpdate(Harddisk h);

        [OperationContract]
        bool HarddiskDelete(int id);
        #endregion

        [OperationContract]
        List<Harddisk> RapporteringHarddisk(string s, string[] keuzeKolommen);


        #region CRUD TblLeverancier
        [OperationContract]
        List<Leverancier> LeverancierGetAll();

        [OperationContract]
        Leverancier LeverancierGetById(int id);

        [OperationContract]
        int LeverancierCreate(Leverancier l);

        [OperationContract]
        bool LeverancierUpdate(Leverancier l);

        [OperationContract]
        bool LeverancierDelete(int id);
        #endregion

        [OperationContract]
        List<Leverancier> RapporteringLeverancier(string s, string[] keuzeKolommen);

        #region CRUD TblLokaal
        [OperationContract]
        List<Lokaal> LokaalGetAll();

        [OperationContract]
        Lokaal LokaalGetById(int id);

        [OperationContract]
        int LokaalCreate(Lokaal l);

        [OperationContract]
        bool LokaalUpdate(Lokaal l);

        [OperationContract]
        bool LokaalDelete(int id);
        #endregion
        [OperationContract]
        List<Lokaal> RapporteringLokaal(string s, string[] keuzeKolommen);

        #region CRUD TblFactuur
        [OperationContract]
        List<Factuur> FactuurGetAll();

        [OperationContract]
        Factuur FactuurGetById(int id);

        [OperationContract]
        int FactuurCreate(Factuur f);

        [OperationContract]
        bool FactuurUpdate(Factuur f);

        [OperationContract]
        bool FactuurDelete(int id);
        #endregion
        [OperationContract]
        List<Factuur> RapporteringFactuur(string s, string[] keuzeKolommen);

        #region CRUD Campus

        [OperationContract]
        List<Campus> CampusGetAll();

        [OperationContract]
        Campus CampusGetById(int id);

        [OperationContract]
        int CampusCreate(Campus c);

        [OperationContract]
        bool CampusUpdate(Campus c);

        [OperationContract]
        bool CampusDelete(int id);

        #endregion
    }

    #region DataContract TblAccount
    [DataContract]
    public class Account
    {
        [DataMember]
        public int IdAccount { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Wachtwoord { get; set; }
    }
    #endregion

    #region DataContract TblSession
    [DataContract]
    public class Session
    {
        [DataMember]
        public int IdSession { get; set; }

        [DataMember]
        public int IdAccount { get; set; }

        [DataMember]
        public string Device { get; set; }

        [DataMember]
        public DateTime Tijdstip { get; set; }
    }
    #endregion

    #region DataContract TblTicketing
    [DataContract]
    public class Ticket
    {
        [DataMember]
        public int IdTicket { get; set; }

        [DataMember]
        public string Verzender { get; set; }

        [DataMember]
        public string Ontvanger { get; set; }

        [DataMember]
        public DateTime Tijdstip { get; set; }

        [DataMember]
        public string Bericht { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
    #endregion

    #region DataContract TblCpu
    [DataContract]
    public class Cpu
    {
        [DataMember]
        public int IdCpu { get; set; }

        [DataMember]
        public string Merk { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public int Snelheid { get; set; }

        [DataMember]
        public string FabrieksNummer { get; set; }
    }
    #endregion

    #region DataContract TblDevice
    [DataContract]
    public class Device
    {
        [DataMember]
        public int IdDevice { get; set; }

        [DataMember]
        public string Merk { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Serienummer { get; set; }

        [DataMember]
        public bool IsPcCompatibel { get; set; }

        [DataMember]
        public string FabrieksNummer { get; set; }
    }
    #endregion

    #region DataContract TblGrafischeKaart
    [DataContract]
    public class GrafischeKaart
    {
        [DataMember]
        public int IdGrafischeKaart { get; set; }

        [DataMember]
        public string Merk { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Driver { get; set; }

        [DataMember]
        public string FabrieksNummer { get; set; }
    }
    #endregion

    #region DataContract TblInventaris
    public class Inventaris
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public WcfServiceCvoInventaris.Object Object { get; set; }
        public Lokaal Lokaal { get; set; }
        public int Aankoopjaar { get; set; }
        public int Afschrijvingsperiode { get; set; }
        public string Historiek { get; set; }
        public bool IsActief { get; set; }
        public bool IsAanwezig { get; set; }
        public Verzekering Verzekering { get; set; }
    }
    #endregion

    #region DataContract TblObject
    public class Object
    {
        public int Id { get; set; }
        public ObjectTypes ObjectType { get; set; }
        public string Kenmerken { get; set; }
        public Leverancier Leverancier { get; set; }
        public Factuur Factuur { get; set; }
    }
    #endregion

    #region DataContract TblNetwerk
    public class Netwerk
    {
        public int Id { get; set; }
        public string Merk { get; set; }
        public string Type { get; set; }
        public string Snelheid { get; set; }
        public string Driver { get; set; }
    }
    #endregion

    #region DataContract TblHardware
    [DataContract]
    public class Hardware
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Cpu Cpu { get; set; }
        [DataMember]
        public Device Device { get; set; }
        [DataMember]
        public GrafischeKaart GrafischeKaart { get; set; }
        [DataMember]
        public Harddisk Harddisk { get; set; }
    }

    #endregion

    #region DataContract TblObjectType
    [DataContract]
    public class ObjectTypes
    {
        private Int32 id;
        private string omschrijving;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Omschrijving
        {
            get { return omschrijving; }
            set { omschrijving = value; }
        }
    }
    #endregion

    #region DataContract TblVerzekering
    [DataContract]
    public class Verzekering
    {
        private Int32 id;
        private string omschrijving;

        [DataMember]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        [DataMember]
        public string Omschrijving
        {
            get
            {
                return omschrijving;
            }

            set
            {
                omschrijving = value;
            }
        }
    }
    #endregion

    #region DataContract TblHarddisk
    [DataContract]
    public class Harddisk
    {
        [DataMember]
        public int IdHarddisk { get; set; }

        [DataMember]
        public string Merk { get; set; }

        [DataMember]
        public int Grootte { get; set; }

        [DataMember]
        public string FabrieksNummer { get; set; }
    }
    #endregion

    #region DataContract TblLeverancier
    [DataContract]
    public class Leverancier
    {
        [DataMember]
        public int IdLeverancier { get; set; }

        [DataMember]
        public string Naam { get; set; }

        [DataMember]
        public string Afkorting { get; set; }

        [DataMember]
        public string Straat { get; set; }

        [DataMember]
        public int HuisNummer { get; set; }

        [DataMember]
        public int BusNummer { get; set; }

        [DataMember]
        public int Postcode { get; set; }

        [DataMember]
        public string Telefoon { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Website { get; set; }

        [DataMember]
        public string BtwNummer { get; set; }

        [DataMember]
        public string Iban { get; set; }

        [DataMember]
        public string Bic { get; set; }

        [DataMember]
        public DateTime ToegevoegdOp { get; set; }
    }
    #endregion

    #region DataContract TblLokaal
    [DataContract]
    public class Lokaal
    {
        [DataMember]
        public int IdLokaal { get; set; }

        [DataMember]
        public string LokaalNaam { get; set; }

        [DataMember]
        public int AantalPlaatsen { get; set; }

        [DataMember]
        public bool IsComputerLokaal { get; set; }
    }
    #endregion

    #region DataContract TblFactuur
    [DataContract]
    public class Factuur
    {
        [DataMember]
        public int IdFactuur { get; set; }

        [DataMember]
        public string Boekjaar { get; set; }

        [DataMember]
        public string CvoVolgNummer { get; set; }

        [DataMember]
        public string FactuurNummer { get; set; }

        [DataMember]
        public string ScholengroepNummer { get; set; }

        [DataMember]
        public DateTime FactuurDatum { get; set; }

        [DataMember]
        public Leverancier Leverancier { get; set; }

        [DataMember]
        public int Prijs { get; set; }

        [DataMember]
        public int Garantie { get; set; }

        [DataMember]
        public string Omschrijving { get; set; }

        [DataMember]
        public string Opmerking { get; set; }

        [DataMember]
        public int Afschrijfperiode { get; set; }

        [DataMember]
        public DateTime DatumInsert { get; set; }

        [DataMember]
        public string UserInsert { get; set; }

        [DataMember]
        public DateTime DatumModified { get; set; }

        [DataMember]
        public string UserModified { get; set; }
    }
    #endregion

    #region DataContract TblCampus
    [DataContract]
    public class Campus
    {
        [DataMember]
        public int IdCampus { get; set; }

        [DataMember]
        public string Naam { get; set; }

        [DataMember]
        public string Postcode { get; set; }

        [DataMember]
        public string Straat { get; set; }

        [DataMember]
        public string Nummer { get; set; }
    }
    #endregion

}