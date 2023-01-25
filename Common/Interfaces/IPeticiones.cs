
using System;
using Microsoft.AspNetCore.Mvc;

namespace Common.Interfaces
{

    /// <summary>
    /// Interface para peticiones sin multiples entidades.
    /// </summary>
    /// <typeparam name="C">modelCreate</typeparam>
    /// <typeparam name="R">modelRead</typeparam>
    /// <typeparam name="U">modeloUpdate</typeparam>
    /// <typeparam name="D">modelDelete</typeparam>
    interface IPeticiones<C, R, U, D> : IGet<R>, IPost<C>, IPut<U>, IDelete<D>
    {

    }
    /// <summary>
    /// Interface para peticiones con multiples entidades en GET all
    /// </summary>
    /// <typeparam name="C">modelCreate</typeparam>
    /// <typeparam name="R">modelRead</typeparam>
    /// <typeparam name="U">modeloUpdate</typeparam>
    interface IPeticiones<C, R, U> : IGetEntidades<R>, IPost<C>, IPut<U>, IDelete
    {

    }


    interface IGet<R>
    {
        ActionResult Get([FromQuery] R r);
        ActionResult Get(int id);
    }

    interface IGetEntidades<R>
    {
        ActionResult Get(int id);
        ActionResult Get([FromHeader] string entidades, [FromQuery] R r);
    }

    interface IPost<T>
    {
        ActionResult Post([FromBody] T obj);
    }


    interface IPut<T>
    {
        ActionResult Put(int id, [FromBody] T obj);
    }

    interface IDelete<T>
    {
        ActionResult Delete(int id, [FromBody] T obj);
    }
    interface IDelete
    {
        ActionResult Delete(int id);
    }
}