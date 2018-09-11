using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaSolid
{
    public interface IPartinerRepository
    {
        /// <summary>
        /// Deve retornar todos os participantes
        /// </summary>
        /// <returns></returns>
        List<Partiner> GetAll();

        /// <summary>
        /// Deve inserir um participante
        /// </summary>
        /// <param name="partiner"></param>
        void Insert(Partiner partiner);
    }
}
