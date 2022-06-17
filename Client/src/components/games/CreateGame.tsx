import axios, { AxiosResponse } from "axios"
import { useEffect, useState } from "react"
import { gameCenterDTO } from "../gamecenters/models/GameCenterDTO.model"
import { genreDTO } from "../genres/models/Genres.model"
import { GameForm } from "./GameForm"
import { UrlGames } from "../../constants/endpoints"
import { GameCreationDto, gamesPostGetDto } from "./models/games.model"
import { Loading } from "../utils/Loading"
import { convertGameToFormData } from "../../helpers/formData"
import { useHistory } from "react-router-dom"
import { DisplayErrors } from "../errorHandling/DisplayErrors"
import { title } from "../../constants/GameCenterVariables"

export const CreateGame = () => {
    document.title = `${title} - Create Game`
    const history = useHistory();

    // the default value of nonSelectedGenres is an empty array
    // it is of type genreDTO[] which is an array of genreDTO objects
    const [nonSelectedGenres, setNonSelectedGenres] = useState<genreDTO[]>([]) 
    // the default value of nonSelectedGameCenters is an empty array
    // it is of type gameCenterDTO[] which is an array of gameCenterDTO objects
    const [nonSelectedGameCenters, setNonSelectedGameCenters] = useState<gameCenterDTO[]>([])
    const [errors, setErrors] = useState<string[]>([])
    const [loading, setLoading] = useState(true)

    // this useEffect is to get the genres and game centers
    useEffect(() => {
        axios.get(`${UrlGames}/postget`)
            .then((response: AxiosResponse<gamesPostGetDto>) => {
                setNonSelectedGenres(response.data.genres)
                setNonSelectedGameCenters(response.data.gameCenter)
                setLoading(false);
            })
    }, []) // an empty array means this useEffect will only run once, when the component is mounted

    // this is the create function that is called when the form is submitted
    // it takes the form data and sends it to the server
    // it then redirects to the game page
    const create = async(game: GameCreationDto) => {
        try{
            const formData = convertGameToFormData(game);
            const response = await axios({
                method: "post",
                url: UrlGames,
                data: formData,
                headers: {
                    "Content-Type": "multipart/form-data"
                }
            })

                 //this response.data returns the game id, so we can redirect to the game page
                 //we can also use the response.data.id to get the game id
                 //but we need to use the history.push method to redirect to the game page
            history.push(`/game/${response.data}`)
        }
        catch(e){
            //this error is returned from the server
            //we can use the error.response.data.errors to get the errors
            //but we need to use the setErrors method to set the errors
            setErrors(e.response.data)
        }
    }
    return(
        <>
            <h3>Create Game</h3>
            <DisplayErrors errors={errors}/> {/* this is the error component that displays the errors from the server*/}
            {/*this is the game form component that creates the game*/}
            {loading ? <Loading /> :
            <GameForm model={{title: '', newlyReleased: false, trailer: ''}}
                onSubmit={async values => await create(values)}
                nonSelectedGenres={nonSelectedGenres}
                selectedGenres={[]}
                
                nonSelectedGameCenters={nonSelectedGameCenters}
                selectedGameCenters={[]}
                selectedActors={[]} /> }
        </>
    )
}