import { genreDTO } from "../genres/models/GenreDTOs.model"
import { gameCenterDTO } from "../gamecenters/models/GameCenterDTO.model"
import { GameForm } from "./GameForm"
import { actorGameDto } from "../actors/model/actorsDTOs.model"

export const EditGame = () => {

    const nonSelectedGenres: genreDTO[] = [{id: 2, name: "Action"}, {id: 3, name: "Adventure"}]
    const selectedGenres: genreDTO[] = [{id: 1, name: "RPG"}, {id: 2, name: "Action"}]
    const nonSelectedGameCenters: gameCenterDTO[] = [{id: 1, name: "Småland", latitude: 57.78066842497087, longitude: 14.16906738333637}]
    const selectedGameCenters: gameCenterDTO[] = [{id: 1, name: "Småland", latitude: 57.78066842497087, longitude: 14.16906738333637}]
    
    const selectedActors: actorGameDto[] = [{id: 1, name: "Actor 1", character: "Character 1", picture: "https://i.gifer.com/ZZ5H.gif"}]

    return(
        <>
            <h3>Edit Game Center</h3>
            <GameForm model={{title: 'Red Dead Redemption 2', newlyReleased: false, trailer: 'url', releaseDate: new Date("2018-01-01T++:00:00")}}
                onSubmit={values => console.log(values)}
                nonSelectedGenres={nonSelectedGenres}
                selectedGenres={selectedGenres}
                
                nonSelectedGameCenters={nonSelectedGameCenters}
                selectedGameCenters={selectedGameCenters}
                selectedActors={selectedActors} />
        </>
    )
}