import { UrlGameCenters } from "../../constants/endpoints";
import { title } from "../../constants/GameCenterVariables";
import { EditEntity } from "../utils/EditEntity";
import GameCenterForm from "./GameCenterForm";
import { gameCenterCreationDTO, gameCenterDTO } from "./models/GameCenterDTO.model";

export const EditGameCenter = () => {
    document.title = `${title} - Edit Game Centers`
    return(
        <EditEntity<gameCenterCreationDTO, gameCenterDTO>
            url={UrlGameCenters} indexUrl="/gamecenters" entityName="Game Center">
                {(entity, edit) => 
                <GameCenterForm model={entity} onSubmit={async values => await edit(values)} />
                }
        </EditEntity>
    )
}