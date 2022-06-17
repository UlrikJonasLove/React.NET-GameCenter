import { UrlGameCenters } from "../../constants/endpoints"
import { Delete, title } from "../../constants/GameCenterVariables"
import { IndexEntity } from "../utils/IndexEntity"
import { gameCenterDTO } from "./models/GameCenterDTO.model"

export const GameCenters = () => {
    document.title = `${title} - ${title}s`
    return(
        <IndexEntity<gameCenterDTO>
            url={UrlGameCenters} createUrl="gamecenters/create" title="Game Centers" entityName="Game Centers">
                {(entities, buttons) =>
                <>
                <thead>
                    <tr>
                        <td></td>
                        <td>Name</td>
                    </tr>
                </thead>
                <tbody>
                    {entities?.map(entity => 
                    <tr key={entity.id}>
                        <td>
                            {buttons(`/gamecenters/edit/${entity.id}`, `${Delete} ${entity.name}`, `${Delete}`, entity.id)}
                        </td>
                        <td>
                            {entity.name}
                        </td>
                    </tr>)}
                </tbody>
                </>
                }
        </IndexEntity>
    )
}