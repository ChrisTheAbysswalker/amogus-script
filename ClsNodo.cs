using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
	internal class ClsNodo
	{
		// clase nodo lista sencilla
		private String Data;
		private ClsNodo Next;

		public ClsNodo(String Data, ClsNodo Next)
		{
			this.Data = Data;
			this.Next = Next;
		}

		public String getData()
		{
			return Data;
		}

		public void setData(String Data)
		{
			this.Data = Data;
		}

		public ClsNodo getNext()
		{
			return Next;
		}

		public void setNext(ClsNodo Next)
		{
			this.Next = Next;
		}
	}
}
