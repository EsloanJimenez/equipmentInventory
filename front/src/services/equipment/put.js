import axios from "axios"
import { show_alert } from "../../utils/swal";
import { API_BASE_URL } from "../../utils/apiBaseURL";

export const putEquipment = async (id, data) => {
   try {
      const res = await axios.put(`${API_BASE_URL}Equipment/${id}`,
         data
      );

      if (res.status === 200)
         show_alert('Equipo actualizado con exito.', 'success');

   } catch (err) {
      if (err.response.data)
         show_alert(err.response.data, 'warning')
   }
}