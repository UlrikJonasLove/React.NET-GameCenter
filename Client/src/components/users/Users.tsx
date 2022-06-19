import axios from "axios"
import Swal from "sweetalert2"
import { UrlUsers } from "../../constants/endpoints"
import { customConfirm } from "../../helpers/customConfirm"
import { Button } from "../utils/Button"
import { IndexEntity } from "../utils/IndexEntity"
import { userDto } from "./model/users.model"

export const Users = () => {
    const assignAdminClaim = async (id: string) => {
        await adminClaim(`${UrlUsers}/assignAdminClaim`, id, "Successfully assigned admin role")
    }

    const removeAdminClaim = async (id: string) => {
        await adminClaim(`${UrlUsers}/removeAdminClaim`, id, "Successfully removed admin role")
    }

    const adminClaim = async (url: string, id: string, swalText: string) => {
        await axios.post(url, id, {
            headers: {
                "Content-Type": "application/json"
            }
        });

        Swal.fire({
            title: "Success",
            text: swalText,
            icon: "success",
        })
    }

    return(
        <IndexEntity<userDto>
            title="Users" url={`${UrlUsers}/listUsers`} entityName="User">

        {users => 
        <>
            <thead>
                <tr>
                    <th></th>
                    <th>Email</th>
                </tr>
                
            </thead>
            <tbody>
                {users?.map(user => 
                <tr key={user.id}>
                    <td>
                        <Button
                            onClick={() => 
                            customConfirm(() => 
                            assignAdminClaim(user.id), 
                            `Assign Admin Role to ${user.email}`, "Yes")}>Assign Admin Role</Button>

                        <Button className="btn btn-danger ms-2"
                            onClick={() => 
                            customConfirm(() => 
                            removeAdminClaim(user.id), 
                            `Remove Admin Role to ${user.email}`, "Yes")}>Remove Admin Role</Button>
                    </td>
                    <td>{user.email}</td>
                </tr>)}
            </tbody>
        </>}
        </IndexEntity>
    )
}