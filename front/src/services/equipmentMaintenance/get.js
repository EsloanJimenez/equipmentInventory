import axios from 'axios'
import { API_BASE_URL } from '../../utils/apiBaseURL';

export const getEquipmentsByTask = async (id) => {
   try {
      const res = await axios(`${API_BASE_URL}EquipmentMaintenance/task/${id}/equipments`);
      return await res.data;
   } catch (err) {
      console.log(`Error al obtener los equipos asignados: ${err}`);
      throw err;
   }
}