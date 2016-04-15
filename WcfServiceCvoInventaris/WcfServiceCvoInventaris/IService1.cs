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
        Netwerk NetwerkGetById(int id);
        [OperationContract]
        bool NetwerkUpdate(Netwerk Netwerk);
        [OperationContract]
        bool NetwerkDelete(int id);
        #endregion

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
    }

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
        public int id { get; set; }
        public string label { get; set; }
        public int idObject { get; set; }
        public int idLokaal { get; set; }
        public int aankoopjaar { get; set; }
        public int afschrijvingsperiode { get; set; }
        public string historiek { get; set; }
        public bool isActief { get; set; }
        public bool isAanwezig { get; set; }
        public int idVerzekering { get; set; }
    }
    #endregion

    #region DataContract TblObject
    public class Object
    {
        public int id { get; set; }
        public int idObjectType { get; set; }
        public string kenmerken { get; set; }
        public int idLeverancier { get; set; }
        public int idFactuur { get; set; }
    }
    #endregion

    #region DataContract TblNetwerk
    public class Netwerk
    {
        public int id { get; set; }
        public string merk { get; set; }
        public string type { get; set; }
        public string snelheid { get; set; }
        public string driver { get; set; }
    }
    #endregion

    #region DataContract TblHardware
    [DataContract]
    public class Hardware
    {
        private int idHardware, idCpu, idDevice, idGrafischeKaart, idHarddisk;

        [DataMember]
        public int IdCpu
        {
            get { return idCpu; }
            set { idCpu = value; }
        }
        [DataMember]
        public int IdDevice
        {
            get { return idDevice; }
            set { idDevice = value; }
        }
        [DataMember]
        public int IdGrafischeKaart
        {
            get { return idGrafischeKaart; }
            set { idGrafischeKaart = value; }
        }
        [DataMember]
        public int IdHarddisk
        {
            get { return idHarddisk; }
            set { idHarddisk = value; }
        }
        [DataMember]
        public int IdHardware
        {
            get
            { return idHardware; }
            set
            { idHardware = value; }
        }
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
        public int idHarddisk { get; set; }

        [DataMember]
        public string merk { get; set; }

        [DataMember]
        public int grootte { get; set; }

        [DataMember]
        public string fabrieksNummer { get; set; }
    }
    #endregion

    #region DataContract TblLeverancier
    [DataContract]
    public class Leverancier
    {
        [DataMember]
        public int idLeverancier { get; set; }

        [DataMember]
        public string naam { get; set; }

        [DataMember]
        public string afkorting { get; set; }

        [DataMember]
        public string straat { get; set; }

        [DataMember]
        public int huisNummer { get; set; }

        [DataMember]
        public int busNummer { get; set; }

        [DataMember]
        public int postcode { get; set; }

        [DataMember]
        public string telefoon { get; set; }

        [DataMember]
        public string fax { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string website { get; set; }

        [DataMember]
        public string btwNummer { get; set; }

        [DataMember]
        public string iban { get; set; }

        [DataMember]
        public string bic { get; set; }

        [DataMember]
        public DateTime toegevoegdOp { get; set; }
    }
    #endregion

    #region DataContract TblLokaal
    [DataContract]
    public class Lokaal
    {
        [DataMember]
        public int idLokaal { get; set; }

        [DataMember]
        public string lokaalNaam { get; set; }

        [DataMember]
        public int aantalPlaatsen { get; set; }

        [DataMember]
        public bool isComputerLokaal { get; set; }

        [DataMember]
        public int idNetwerk { get; set; }
    }
    #endregion

    #region DataContract TblFactuur
    [DataContract]
    public class Factuur
    {
        [DataMember]
        public int idFactuur { get; set; }

        [DataMember]
        public string Boekjaar { get; set; }

        [DataMember]
        public string CvoVolgNummer { get; set; }

        [DataMember]
        public string FactuurNummer { get; set; }

        [DataMember]
        public DateTime FactuurDatum { get; set; }

        [DataMember]
        public bool FactuurStatusGetekend { get; set; }

        [DataMember]
        public DateTime VerwerkingsDatum { get; set; }

        [DataMember]
        public int idLeverancier { get; set; }

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
        public string OleDoc { get; set; }

        [DataMember]
        public string OleDocPath { get; set; }

        [DataMember]
        public string OleDocFileName { get; set; }

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


}