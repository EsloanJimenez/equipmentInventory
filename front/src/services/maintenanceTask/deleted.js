import axios from "axios";
import { show_alert } from "../../utils/swal";
import { API_BASE_URL } from "../../utils/apiBaseURL";

export const deleteMaintenanceTask = async (id, description) => {

   const res = await axios.delete(`${API_BASE_URL}MaintenanceTask/${id}`, {
      data: {
         Id: id,
         Description: description,
      }
   });

   if (res.status === 200 || res.status === 204)
      show_alert('Tarea eliminado con exito.', 'success');

}