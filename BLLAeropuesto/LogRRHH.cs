using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class LogRRHH
    {
    public void AgregadosRRHH(RRHH recursos)
    {
        CRUDrrhh objeto = new CRUDrrhh();
        objeto.InsertUpdateAsociado(recursos, "1");
    }

    public void ActualizarAsociados(RRHH recurso)
    {
        CRUDrrhh objeto = new CRUDrrhh();
        objeto.InsertUpdateAsociado(recurso, "2");
    }

    public void EliminarAsociados(string CategoriaID)
    {
        CRUDrrhh objeto = new CRUDrrhh();
        objeto.DeleteAsociado(CategoriaID);
    }

    public void BuscarAsociado(string CategoriaID)
    {
        CRUDrrhh objeto = new CRUDrrhh();
        objeto.BuscarAsociado(CategoriaID);
    }

    public RRHH ValidarAsociado(string CategoriaID, string Clave)
    {
        CRUDrrhh objeto = new CRUDrrhh();
        return objeto.ValidarAsociado(CategoriaID, Clave);
    }

    public List<RRHH> ListarAsociados()
    {
        CRUDrrhh objeto = new CRUDrrhh();
        return objeto.GetRecurso();
    }
}

