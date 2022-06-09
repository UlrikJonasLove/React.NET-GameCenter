import axios from "axios";
import { useState } from "react";
import { useHistory } from "react-router-dom";
import { UrlActors } from "../../constants/endpoints";
import { convertActorToFormData } from "../../helpers/formData";
import { DisplayErrors } from "../errorHandling/DisplayErrors";
import { ActorForm } from "./ActorForm"
import { actorCreationDTO } from "./model/actorsDTOs.model"

export const CreateActor = () => {
    const [errors, setErrors] = useState<string[]>([]);
    const history = useHistory();

    const create = async(actor: actorCreationDTO) => {
        try{
            const formData = convertActorToFormData(actor)
            await axios({
                method: "post",
                url: UrlActors,
                data: formData,
                headers: {
                    "Content-Type": "multipart/form-data"}
            });
            history.push("/actors");
        }
        catch(error){
            if(error && error.response){
                setErrors(error.response.data);
            }
        }
    }

    return(
        <>
            <h3>Create Actor</h3>
            <DisplayErrors errors={errors} />
            <ActorForm model={{name: "", dateOfBirth: undefined}}
                onSubmit={async values => await create(values)}/>
        </>
    )
}