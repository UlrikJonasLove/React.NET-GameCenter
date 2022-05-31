import axios, { AxiosResponse} from "axios";
import { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom"
import { UrlGenres } from "../../constants/endpoints";
import { DisplayErrors } from "../errorHandling/DisplayErrors";
import { Loading } from "../utils/Loading";
import { GenreForm } from "./GenreForm";
import { genreCreationDTO } from "./models/Genres.model";

export const EditGenre = () => {
    const {id}:any = useParams()
    const [genre, setGenre] = useState<genreCreationDTO>();
    const [errors, setErrors] = useState<string[]>([]);
    const history = useHistory();

    useEffect(() => {
        axios.get(`${UrlGenres}/${id}`)
            .then((response: AxiosResponse<genreCreationDTO>) => {
                setGenre(response.data)
            })
    }, [id])

    const edit = async (genreToEdit: genreCreationDTO) => {
        try{
            await axios.put(`${UrlGenres}/${id}`, genreToEdit)
            history.push("/genres")
        }
        catch(error) {
            if(error && error.response) {
                setErrors(error.response.data)
            }
        }
    }

    return(
        <>
            <h3>Edit Genre</h3>
            <DisplayErrors errors={errors} />
            {genre ? <GenreForm model={genre} 
            onSubmit={async value => {
                await edit(value)
            }}/> : <Loading />}
            
        </>
    )
}