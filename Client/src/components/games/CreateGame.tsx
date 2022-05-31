import { gameCenterDTO } from "../gamecenters/models/GameCenterDTO.model"
import { genreDTO } from "../genres/models/Genres.model"
import { GameForm } from "./GameForm"

export const CreateGame = () => {

    const nonSelectedGenres: genreDTO[] = [{id: 1, name: "RPG"}, {id: 2, name: "Action"}, {id: 3, name: "Adventure"}]
    const nonSelectedGameCenters: gameCenterDTO[] = [{id: 1, name: "Småland", latitude: 57.78066842497087, longitude: 14.16906738333637}]
    return(
        <>
            <h3>Create Game</h3>
            <GameForm model={{title: '', newlyReleased: false, trailer: ''}}
                onSubmit={values => console.log(values)}
                nonSelectedGenres={nonSelectedGenres}
                selectedGenres={[]}
                
                nonSelectedGameCenters={nonSelectedGameCenters}
                selectedGameCenters={[]}
                selectedActors={[]} />
        </>
    )
}