import axios from "axios";
import { useState } from "react";
import { useHistory } from "react-router-dom";
import { UrlGameCenters } from "../../constants/endpoints";
import { DisplayErrors } from "../errorHandling/DisplayErrors";
import GameCenterForm from "./GameCenterForm";
import { gameCenterCreationDTO } from "./models/GameCenterDTO.model";

export const CreateGameCenter  = () => {
    const history = useHistory();
    const [errors, setErrors] = useState<string[]>([]);

    const create = async (gameCenter: gameCenterCreationDTO) => {
        try{
            await axios.post(UrlGameCenters, gameCenter);
            history.push("/gamecenters");
        }
        catch(error){
            if(error && error.response){
                setErrors(error.response.data);
            }
        }
    }
    return(
        <>
            <h3>Create Game Center</h3>
            <DisplayErrors errors={errors} />
            <GameCenterForm model={{name: ""}} onSubmit={async values => await create(values)} />
        </>
    )
}