using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Veiculo
    {
        public int Id;
        public string Modelo;
        public decimal Valor;

        //propiedade para a coluna id _categoria (FK)
        public int IdCategoria;
        
        //objeto da categoria que permitiria acessar as informaçoes da categoria atraves do veiculo
        public Categoria Categoria;

    }
}
