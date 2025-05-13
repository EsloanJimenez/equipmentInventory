import axios from 'axios'
import { API_BASE_URL } from '../../utils/apiBaseURL';

export const getMaintenanceTask = async () => {
   try {
      const res = await axios(`${API_BASE_URL}MaintenanceTask`);
      return await res.data;
   } catch (err) {
      console.log(`Error al obtener las tareas: ${err}`);
      throw err;
   }
}