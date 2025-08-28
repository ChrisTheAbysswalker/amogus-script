using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
	internal class ClsPila
	{
		private ClsNodo Tope; // inicio
		public int Tam; // tam pila

		public ClsPila()
		{
			Tope = null;
			Tam = 0;
		}

		public void Push(String Value)
		{
			ClsNodo auxiliarNode = new ClsNodo(Value, null);
			if (Tope == null)
			{
				Tope = auxiliarNode;
			}
			else
			{
				auxiliarNode.setNext(Tope);
				Tope = auxiliarNode;
			}
			Tam++; // al agregar aumenta el taman
		}

		public String Pop()
		{
			if (Tope == null)
			{
				return null;
			}
			else
			{
				String Value = Tope.getData(); // guarda el valor borrado
				Tope = Tope.getNext(); // el valor del tope sera el siguiente
				Tam--; // cantidad decrementa
				return Value;
			}
		}

		public String Peek()
		{
			if (Tope == null)
			{
				return null;
			}
			else
			{
				return Tope.getData();
			}
		}

		public bool estavacia()
		{ // si la pila esta vacia es porque size es 0
			return (Tam == 0);
		}

		public int Size()
		{ // retorna el tamano actual
			return Tam;
		}

		public String getAntes()
		{
			string ant = Tope.getNext().getData();
			return ant;
		}
	}
}
