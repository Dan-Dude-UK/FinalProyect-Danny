using System;
using System.Collections.Generic;
using System.Text;

namespace Control_Gastos
{
    public class Gasto
    {
        private int _id;
        private string _descripcion;
        private decimal _monto;
        private DateTime _fecha;

        public Gasto()
        {
            _id = 0;
            _descripcion = string.Empty;
            _monto = 0;
            _fecha = DateTime.Now;
        }

        public Gasto(int id, string descripcion, decimal monto, DateTime fecha)
        {
            _id = id;
            _descripcion = descripcion;
            _monto = monto;
            _fecha = fecha;
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }

        public decimal Monto
        {
            get
            {
                return _monto;
            }

            set
            {
                _monto = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }

            set
            {
                _fecha = value;
            }
        }

        public override string ToString()
        {
            return $"[{_id}] {_descripcion} | Monto: RD${_monto} | Fecha: {_fecha.ToShortDateString()}";
        }
    }
}

