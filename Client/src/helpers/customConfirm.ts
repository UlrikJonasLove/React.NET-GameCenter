import Swal from "sweetalert2"

export const customConfirm = (
    onConfirm: any,
    title: string,
    confirmButtonText: string,
) => {
    Swal.fire({
        title,
        confirmButtonText,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
    }).then(result => {
        if(result.isConfirmed){
            onConfirm()
        }
    })
}