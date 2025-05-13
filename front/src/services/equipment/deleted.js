import axios from "axios";
import { show_alert } from "../../utils/swal";

import { API_BASE_URL } from "../../utils/apiBaseURL";

export const deleteEquipment = async (id, data) => {
   const res = await axios.delete(`${API_BASE_URL}Equipment/${id}`, {
      data: {
         Id: id,
         ...data
      }
   });

   if (res.status === 200 || res.status === 204)
      show_alert('Equipo eliminado con exito.', 'success');

}