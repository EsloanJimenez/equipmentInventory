import axios from 'axios'
import { API_BASE_URL } from '../../utils/apiBaseURL';

export const getEquipment = async () => {
   console.log('estoy aqui');

   try {
      const res = await axios(`${API_BASE_URL}Equipment`);
      return await res.data;
   } catch (err) {
      console.log(`Error al obtener los equipos. : ${err}`);
      throw err;
   }
}