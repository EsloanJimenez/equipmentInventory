import axios from 'axios'
import { API_BASE_URL } from '../../utils/apiBaseURL';

export const getEquipmentType = async () => {
   try {
      const res = await axios(`${API_BASE_URL}EquipmentType`);
      return await res.data;
   } catch (err) {
      console.log(`Error al obtener los tipos de equipos. : ${err}`);
      throw err;
   }
}