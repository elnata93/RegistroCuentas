using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Cuentas : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();

        public int CuentaId { set; get; }
        public string Descripcion { set; get; }
        public double Balance { set; get; }

        public Cuentas()
        {
             CuentaId = 0;
             Descripcion = "";
             Balance = 0;
        }

        public Cuentas(int cuentaId,string descripcion,float balance)
        {
            CuentaId = cuentaId;
            Descripcion = descripcion;
            Balance = balance;
        }

        public override bool Insertar()
        {
            try
            {
                bool retorno = false;
                retorno = conexion.Ejecutar(String.Format("Insert Into Cuentas(Descripcion,Balance) values('{0}',{1}) ",this.Descripcion,this.Balance));
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public override bool Editar()
        {
            try
            {
                bool retorno = false;
                retorno = conexion.Ejecutar(String.Format("Update Cuentas set Descripcion='{0}',Balance={1} where CuentaId={2} ",this.Descripcion,this.Balance,this.CuentaId));
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar()
        {
            try
            {
                bool retorno = false;
                retorno = conexion.Ejecutar(String.Format("Delete from Cuentas where CuentaId={0} ", this.CuentaId));
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public override bool Buscar(int IdBuscado)
        {
            try
            {
                DataTable data = new DataTable();
                data = conexion.ObtenerDatos(String.Format("Select Descripcion,Balance from Cuentas where CuentaId={0} ", IdBuscado));

                if(data.Rows.Count > 0)
                {
                    this.Descripcion = data.Rows[0]["Descripcion"].ToString();
                    this.Balance = (double)data.Rows[0]["Balance"];
                }
                return data.Rows.Count > 0;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            throw new NotImplementedException();
        }
    }
}
