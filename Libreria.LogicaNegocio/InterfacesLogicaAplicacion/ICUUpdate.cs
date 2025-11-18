namespace Libreria.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUUpdate<T>
    {
        void Execute(int id, T Obj);
    }
}
