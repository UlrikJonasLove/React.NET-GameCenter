import { UrlActors } from "../../constants/endpoints"
import { Delete } from "../../constants/GameCenterVariables"
import { IndexEntity } from "../utils/IndexEntity"
import { actorDto } from "./model/actorsDTOs.model"
 

export const Actors = () => {
    document.title = "Game Center - Actors"
    return(
        <IndexEntity<actorDto>
            url={UrlActors} createUrl="actors/create" title="Actors" entityName="Actor">
                {(actors, buttons) => 
                <>
                    <thead>
                        <tr>
                            <th></th>
                            <th>Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {actors?.map(actor => <tr key={actor.id}>
                            <td>{buttons(`actors/edit/${actor.id}`, `${Delete} ${actor.name}`, `${Delete}`, actor.id)}</td>
                            <td>{actor.name}</td>
                        </tr>)}
                    </tbody>
                </>}
        </IndexEntity>
    )
}