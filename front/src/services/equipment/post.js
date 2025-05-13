import axios from "axios"
import { show_alert } from "../../utils/swal";
import { API_BASE_URL } from "../../utils/apiBaseURL";

export const postEquipment = async (data) => {

   try {
      const res = await axios.post(`${API_BASE_URL}Equipment`,
         data
      );

      if (res.status === 200)
         show_alert('Equipo registrado con exito.', 'success');

   } catch (err) {
      if (err.response.data)
         show_alert(err.response.data, 'warning')
   }
}