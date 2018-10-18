using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interface
{
	public interface IPersonaServices
	{
		PersonaBE GetById(Int32 Id);
		List<PersonaBE> GetAll(Int32 state, Int32 page,Int32 idconectado, Int32 pageSize, String orderBy, String ascending, ref Int32 count, Int32 tipo_persona);
		Int64 Create(PersonaBE Be);
		Boolean Update(Int64 Id, PersonaBE Be);
		Boolean Delete(Int32 Id);
		List<PersonaBE> Login(String usermane,String password);
		Boolean ChangePassword(Int64 Id, UsuarioBE Be);
	}
}
