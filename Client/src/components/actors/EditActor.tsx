import { UrlActors } from "../../constants/endpoints";
import { convertActorToFormData } from "../../helpers/formData";
import { EditEntity } from "../utils/EditEntity";
import { ActorForm } from "./ActorForm";
import { actorCreationDTO, actorDto } from './model/actorsDTOs.model'

export const EditActor = () => {
    const transform = (actor: actorDto): actorCreationDTO => {
        return {
            name: actor.name,
            pictureURL: actor.picture,
            biography: actor.biography,
            dateOfBirth: new Date(actor.dateOfBirth),
        }
    }

    return(
        <EditEntity<actorCreationDTO, actorDto>
            url={UrlActors} indexUrl="/actors" entityName="Actor" transformFormData={convertActorToFormData} transform={transform}>
                {(entity, edit) => 
                <ActorForm 
                    model={entity}
                    onSubmit={async values => await edit(values)}/>}
        </EditEntity>
    )
}