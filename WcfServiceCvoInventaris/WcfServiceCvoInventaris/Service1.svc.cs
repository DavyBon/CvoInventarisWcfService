using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using WcfServiceCvoInventaris.DataAccess;

namespace WcfServiceCvoInventaris
{
    public class CvoInventarisService : ICvoInventarisService
    {
        #region FIELDS
        TblCpu tblCpu;
        TblDevice tblDevice;
        TblGrafischeKaart tblGrafischeKaart;
        TblInventaris inv;
        TblNetwerk net;
        TblObject obj;
        TblObjectType tblObjectType;
        TblVerzekering tblVerzekering;
        TblHardware tblHardware;
        TblHarddisk dataHarddisk;
        TblLeverancier dataLeverancier;
        TblLokaal dataLokaal;
        SqlConnection connection = new SqlConnection("Data Source=92.222.220.213,1500;Initial Catalog=CvoInventarisdb;Persist Security Info=True;User ID=sa;Password=grati#s1867");
        SqlCommand command;
        #endregion

        #region CONSTRUCTOR
        public CvoInventarisService()
        {
            tblCpu = new TblCpu();
            tblDevice = new TblDevice();
            tblGrafischeKaart = new TblGrafischeKaart();
            inv = new TblInventaris();
            net = new TblNetwerk();
            obj = new TblObject();
            tblObjectType = new TblObjectType();
            tblVerzekering = new TblVerzekering();
            tblHardware = new TblHardware();
            dataHarddisk = new TblHarddisk();
            dataLeverancier = new TblLeverancier();
            dataLokaal = new TblLokaal();
        }
        #endregion

        #region CRUD TblCpu
        public Cpu CpuGetById(int id)
        {
            return tblCpu.GetById(id);
        }

        public List<Cpu> CpuGetAll()
        {
            return tblCpu.GetAll();
        }

        public int CpuCreate(Cpu c)
        {
            return tblCpu.Create(c);
        }

        public bool CpuUpdate(Cpu c)
        {
            return tblCpu.Update(c);
        }

        public bool CpuDelete(int id)
        {
            return tblCpu.Delete(id);
        }
        #endregion

        #region CRUD TblDevice
        public Device DeviceGetById(int id)
        {
            return tblDevice.GetById(id);
        }

        public List<Device> DeviceGetAll()
        {
            return tblDevice.GetAll();
        }

        public int DeviceCreate(Device d)
        {
            return tblDevice.Create(d);
        }

        public bool DeviceUpdate(Device d)
        {
            return tblDevice.Update(d);
        }

        public bool DeviceDelete(int id)
        {
            return tblDevice.Delete(id);
        }
        #endregion

        #region CRUD TblGrafischeKaart
        public GrafischeKaart GrafischeKaartGetById(int id)
        {
            return tblGrafischeKaart.GetById(id);
        }

        public List<GrafischeKaart> GrafischeKaartGetAll()
        {
            return tblGrafischeKaart.GetAll();
        }

        public int GrafischeKaartCreate(GrafischeKaart gk)
        {
            return tblGrafischeKaart.Create(gk);
        }

        public bool GrafischeKaartUpdate(GrafischeKaart gk)
        {
            return tblGrafischeKaart.Update(gk);
        }

        public bool GrafischeKaartDelete(int id)
        {
            return tblGrafischeKaart.Delete(id);
        }
        #endregion

        #region CRUD TblInventaris
        public int InventarisCreate(Inventaris inventaris)
        {
            return inv.Create(inventaris);
        }

        public bool InventarisDelete(int id)
        {
            if (inv.Delete(id)) return true;
            return false;
        }

        public List<Inventaris> InventarisGetAll()
        {
            List<Inventaris> list = inv.GetAll();
            if (list == null) return null;
            return list;
        }

        public Inventaris InventarisGetById(int id)
        {
            Inventaris inventaris = inv.GetById(id);
            if (inventaris == null) return null;
            return inventaris;
        }

        public bool InventarisUpdate(Inventaris inventaris)
        {
            if (inv.Update(inventaris)) return true;
            return false;
        }
        #endregion

        #region CRUD TblNetwerk
        public int NetwerkCreate(Netwerk netwerk)
        {
            return net.Create(netwerk);
        }

        public bool NetwerkDelete(int id)
        {
            if (net.Delete(id)) return true;
            return false;
        }

        public List<Netwerk> NetwerkGetAll()
        {
            List<Netwerk> list = net.GetAll();
            if (list == null) return null;
            return list;
        }

        public Netwerk NetwerkGetById(int id)
        {
            Netwerk netwerk = net.GetById(id);
            if (netwerk == null) return null;
            return netwerk;
        }

        public bool NetwerkUpdate(Netwerk netwerk)
        {
            if (net.Update(netwerk)) return true;
            return false;
        }
        #endregion

        #region CRUD TblObject
        public int ObjectCreate(Object obj_)
        {
            return obj.Create(obj_);
        }

        public bool ObjectDelete(int id)
        {
            if (obj.Delete(id)) return true;
            return false;
        }

        public List<Object> ObjectGetAll()
        {
            List<Object> list = obj.GetAll();
            if (list == null) return null;
            return list;
        }

        public Object ObjectGetById(int id)
        {
            Object obj_ = obj.GetById(id);
            if (obj_ == null) return null;
            return obj_;
        }

        public bool ObjectUpdate(Object obj_)
        {
            if (obj.Update(obj_)) return true;
            return false;
        }
        #endregion

        #region CRUD ObjectType
        public int ObjectTypeCreate(ObjectTypes objectType)
        {
            return tblObjectType.Create(objectType);
        }

        public ObjectTypes ObjectTypeGetById(int id)
        {
            return tblObjectType.GetById(id);
        }

        public List<ObjectTypes> ObjectTypeGetAll()
        {
            return tblObjectType.GetAll();
        }

        public bool ObjectTypeDelete(int id)
        {
            return tblObjectType.Delete(id);
        }

        public bool ObjectTypeUpdate(ObjectTypes objectType)
        {
            return tblObjectType.Update(objectType);
        }
        #endregion

        #region CRUD Verzekering
        public int VerzekeringCreate(Verzekering verzekering)
        {
            return tblVerzekering.Create(verzekering);
        }

        public bool VerzekeringDelete(int id)
        {
            return tblVerzekering.Delete(id);
        }

        public List<Verzekering> VerzekeringGetAll()
        {
            return tblVerzekering.GetAll();
        }

        public Verzekering VerzekeringGetById(int id)
        {
            return tblVerzekering.GetById(id);
        }

        public bool VerzekeringUpdate(Verzekering verzekering)
        {
            return tblVerzekering.Update(verzekering);
        }
        #endregion

        #region CRUD TblObject
        public int HardwareCreate(Hardware hardware)
        {
            return tblHardware.Create(hardware);
        }

        public Hardware HardwareGetById(int id)
        {
            return tblHardware.GetById(id);
        }

        public List<Hardware> HardwareGetAll()
        {
            return tblHardware.GetAll();
        }

        public bool HardwareUpdate(Hardware hardware)
        {
            return tblHardware.Update(hardware);
        }

        public bool HardwareDelete(int id)
        {
            return tblHardware.Delete(id);
        }
        #endregion

        #region CRUD TblHarddisk
        public List<Harddisk> HarddiskGetAll()
        {
            List<Harddisk> list = dataHarddisk.GetAll();
            if (list == null) return null;
            return list;
        }

        public Harddisk HarddiskGetById(int id)
        {
            Harddisk h = dataHarddisk.GetById(id);
            if (h == null) return null;
            return h;
        }

        public int HarddiskCreate(Harddisk h)
        {
            try { return dataHarddisk.Create(h); }
            catch { return -1; }
        }

        public bool HarddiskUpdate(Harddisk h)
        {
            if (dataHarddisk.Update(h)) return true;
            return false;
        }

        public bool HarddiskDelete(int id)
        {
            if (dataHarddisk.Delete(id)) return true;
            return false;
        }
        #endregion

        #region CRUD TblLeverancier
        public List<Leverancier> LeverancierGetAll()
        {
            List<Leverancier> list = dataLeverancier.GetAll();
            if (list == null) return null;
            return list;
        }

        public Leverancier LeverancierGetById(int id)
        {
            Leverancier l = dataLeverancier.GetById(id);
            if (l == null) return null;
            return l;
        }

        public int LeverancierCreate(Leverancier l)
        {
            try { return dataLeverancier.Create(l); }
            catch { return -1; }
        }

        public bool LeverancierUpdate(Leverancier l)
        {
            if (dataLeverancier.Update(l)) return true;
            return false;
        }

        public bool LeverancierDelete(int id)
        {
            if (dataLeverancier.Delete(id)) return true;
            return false;
        }
        #endregion

        #region CRUD TblLokaal
        public List<Lokaal> LokaalGetAll()
        {
            List<Lokaal> list = dataLokaal.GetAll();
            if (list == null) return null;
            return list;
        }

        public Lokaal LokaalGetById(int id)
        {
            Lokaal l = dataLokaal.GetById(id);
            if (l == null) return null;
            return l;
        }

        public int LokaalCreate(Lokaal l)
        {
            try { return dataLokaal.Create(l); }
            catch { return -1; }
        }

        public bool LokaalUpdate(Lokaal l)
        {
            if (dataLokaal.Update(l)) return true;
            return false;
        }

        public bool LokaalDelete(int id)
        {
            if (dataLokaal.Delete(id)) return true;
            return false;
        }
        #endregion
    }
}