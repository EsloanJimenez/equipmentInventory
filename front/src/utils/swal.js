import Swal from "sweetalert2";

export const show_alert = (mensaje, icono, foco = '') => {
   onfocus(foco);

   Swal.fire({
      title: mensaje,
      icon: icono
   });
}

const onfocus = (foco) => {
   if (foco !== '')
      document.getElementById(foco).focus();
}
