import axios from 'axios';
import { useState } from 'react';
import { useHistory } from 'react-router-dom';
import { UrlGenres } from '../../constants/endpoints';
import { title } from '../../constants/GameCenterVariables';
import { DisplayErrors } from '../errorHandling/DisplayErrors';
import { GenreForm } from './GenreForm'
import { genreCreationDTO } from './models/Genres.model';

export const CreateGenre = () => {
    document.title = `${title} - Create Genre`

    const history = useHistory();
    const [errors, setErrors] = useState<string[]>([]);

    const create = async (genre: genreCreationDTO) => {
        try{
            await axios.post(UrlGenres, genre);
            history.push("/genres");
        }
        catch(error) {
            if(error && error.response) {
                setErrors(error.response.data)
            }
        }
    }
    return(
        <>
            <h3>Create Genre</h3>
            <DisplayErrors errors={errors} />
            <GenreForm model={{name: ""}} 
            onSubmit={async value => {
                await create(value);
            }}/>
        </>
    )
}