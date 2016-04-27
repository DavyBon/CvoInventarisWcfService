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
using WcfServiceCvoInventaris.Helpers;

namespace WcfServiceCvoInventaris
{
    public class CvoInventarisService : ICvoInventarisService
    {
        #region FIELDS
        TblAccount tblAccount;
        TblSession tblSession;
        TblTicketing tblTicketing;
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
        TblFactuur dataFactuur;
        SqlConnection connection = new SqlConnection("Data Source=92.222.220.213,1500;Initial Catalog=CvoInventarisdb;Persist Security Info=True;User ID=sa;Password=grati#s1867");
        #endregion

        #region CONSTRUCTOR
        public CvoInventarisService()
        {
            tblAccount = new TblAccount();
            tblSession = new TblSession();
            tblTicketing = new TblTicketing();
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
            dataFactuur = new TblFactuur();
        }
        #endregion

        #region CRUD TblAccount
        public Account AccountGetById(int id)
        {
            return tblAccount.GetById(id);
        }

        public List<Account> AccountGetAll()
        {
            return tblAccount.GetAll();
        }

        public int AccountCreate(Account a)
        {
            return tblAccount.Create(a);
        }

        public bool AccountUpdate(Account a)
        {
            return tblAccount.Update(a);
        }

        public bool AccountDelete(int id)
        {
            return tblAccount.Delete(id);
        }

        public bool AccountLogin(Account a)
        {
            try
            {
                Account accUitDB = AccountGetByEmail(a.Email);

                if (accUitDB.Wachtwoord == "")
                {
                    // het e-mailadres staat niet in de DB, en returnt daardoor geen wachtwoord
                    return false;
                }
                else
                {
                    // het e-mailadres staat in de DB, en returnde een wachtwoord
                    if (PasswordStorage.VerifyPassword(a.Wachtwoord, accUitDB.Wachtwoord))
                    {
                        // ingegeven email en wachtwoord combinatie zijn juist, log de gebruiker in

                        // sla een session op voor deze login
                        Session s = new Session();
                        s.IdAccount = accUitDB.IdAccount;
                        s.Device = Environment.MachineName;
                        s.Tijdstip = DateTime.Now;
                        SessionCreate(s);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }            
        }

        public Account AccountGetByEmail(string email)
        {
            return tblAccount.GetByEmail(email);
        }
        #endregion

        #region CRUD TblSession
        public Session SessionGetById(int id)
        {
            return tblSession.GetById(id);
        }

        public List<Session> SessionGetAll()
        {
            return tblSession.GetAll();
        }

        public int SessionCreate(Session s)
        {
            return tblSession.Create(s);
        }

        public bool SessionUpdate(Session s)
        {
            return tblSession.Update(s);
        }

        public bool SessionDelete(int id)
        {
            return tblSession.Delete(id);
        }

        public bool SessionGetByAccount(Account a)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CRUD TblTicketing
        public Ticket TicketingGetById(int id)
        {
            return tblTicketing.GetById(id);
        }

        public List<Ticket> TicketingGetAll()
        {
            return tblTicketing.GetAll();
        }

        public int TicketingCreate(Ticket t)
        {
            return tblTicketing.Create(t);
        }

        public bool TicketingUpdate(Ticket t)
        {
            return tblTicketing.Update(t);
        }

        public bool TicketingDelete(int id)
        {
            return tblTicketing.Delete(id);
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

        #region CRUD TblFactuur
        public List<Factuur> FactuurGetAll()
        {
            List<Factuur> list = dataFactuur.GetAll();
            if (list == null) return null;
            return list;
        }

        public Factuur FactuurGetById(int id)
        {
            Factuur f = dataFactuur.GetById(id);
            if (f == null) return null;
            return f;
        }

        public int FactuurCreate(Factuur f)
        {
            try { return dataFactuur.Create(f); }
            catch { return -1; }
        }

        public bool FactuurUpdate(Factuur f)
        {
            if (dataFactuur.Update(f)) return true;
            return false;
        }

        public bool FactuurDelete(int id)
        {
            if (dataFactuur.Delete(id)) return true;
            return false;
        }
        #endregion
        public List<Cpu> RapporteringCpu(string s, string[] keuzeKolommen)
        {
            return tblCpu.Rapportering(s, keuzeKolommen);
        }

        public List<Device> RapporteringDevice(string s, string[] keuzeKolommen)
        {
            return tblDevice.Rapportering(s, keuzeKolommen);
        }

        public List<GrafischeKaart> RapporteringGrafischeKaart(string s, string[] keuzeKolommen)
        {
            return tblGrafischeKaart.Rapportering(s, keuzeKolommen);
        }

        public List<Harddisk> RapporteringHarddisk(string s, string[] keuzeKolommen)
        {
            return dataHarddisk.Rapportering(s, keuzeKolommen);
        }

        public List<Netwerk> RapporteringNetwerk(string s, string[] keuzeKolommen)
        {
            return net.Rapportering(s, keuzeKolommen);
        }

        public List<Leverancier> RapporteringLeverancier(string s, string[] keuzeKolommen)
        {
            return dataLeverancier.Rapportering(s, keuzeKolommen);
        }
    }
}