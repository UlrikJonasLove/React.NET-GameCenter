import { GameForm } from "./GameForm"
import { useEffect, useState } from "react"
import axios, { AxiosResponse } from "axios"
import { UrlGames } from "../../constants/endpoints"
import { useHistory, useParams } from "react-router-dom"
import { GameCreationDto, gamePutGetDto } from "./models/games.model"
import { convertGameToFormData } from "../../helpers/formData"
import { DisplayErrors } from "../errorHandling/DisplayErrors"

export const EditGame = () => {
    const history = useHistory();
    const {id}:any = useParams()
    const [game, setGame] = useState<GameCreationDto>();
    const [gamePutGet, setGamePutGet] = useState<gamePutGetDto>();
    const [errors, setErrors] = useState<string[]>([]);

    useEffect(() =>{
        axios.get(`${UrlGames}/PutGet/${id}`)
            .then((response: AxiosResponse<gamePutGetDto>) => {
                const model: GameCreationDto = {
                    title: response.data.game.title,
                    newlyReleased: response.data.game.newlyReleased,
                    trailer: response.data.game.trailer,
                    posterUrl: response.data.game.poster,
                    summary: response.data.game.summary,
                    releaseDate: new Date(response.data.game.releaseDate)
                };

                setGame(model);
                setGamePutGet(response.data)
            })
    }, [id])

    const edit = async(gameToEdit: GameCreationDto) => {
        try {
            const formData = convertGameToFormData(gameToEdit);
            await axios({
                method: "put",
                url: `${UrlGames}/${id}`,
                data: formData,
                headers: {
                    "Content-Type": "multipart/form-data"
                }
            });
            history.push(`/game/${id}`);
        }
        catch(error) {
            setErrors(error.response.data);
        }
    }

    return(
        <>
            <h3>Edit Game</h3>
            <DisplayErrors errors={errors} />
            {game && gamePutGet ? 
            <GameForm model={game}
                onSubmit={async values => await edit(values)}
                nonSelectedGenres={gamePutGet.nonSelectedGenres}
                selectedGenres={gamePutGet.selectedGenres}
                
                nonSelectedGameCenters={gamePutGet.nonSelectedGameCenters}
                selectedGameCenters={gamePutGet.SelectedGameCenters}
                selectedActors={gamePutGet.actors} />
            : null}
        </>
    )
}