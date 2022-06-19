import { GameDto } from "./models/games.model";
import css from "./css/IndividualGame.module.css";
import { Link } from "react-router-dom";
import { Button } from "../utils/Button";
import { customConfirm } from "../../helpers/customConfirm";
import { Delete } from "../../constants/GameCenterVariables";
import axios from "axios";
import { UrlGames } from "../../constants/endpoints";
import { useContext } from "react";
import { AlertContext } from "../../helpers/alertContext";
import { Authorized } from "../auth/Authorized";

export const IndividualGame = (props: GameDto) => {
    const buildLink = () => `/game/${props.id}`
    const customAlert = useContext(AlertContext)

    const onDelete = () => {
        axios.delete(`${UrlGames}/${props.id}`)
            .then(() => {
                customAlert();
            });
    }

    return (
        <article className={css.game}>
            <Link to={buildLink()}>
                
                {props.poster ? <img alt="Poster" src={props.poster}/> 
                : <img alt="No game poster found" src="https://cdn.pixabay.com/photo/2016/03/08/07/08/question-1243504_960_720.png"/>}
            </Link>
            <p>
                <Link to={buildLink()}>{props.title}</Link>
            </p>
            <Authorized 
                role="admin"
                authorized={<>
                    <section>
                        <Link style={{marginRight: '1rem'}} className="btn btn-info" to={`/game/edit/${props.id}`}>Edit</Link>
                        <Button onClick={() => customConfirm(() => onDelete(), `${Delete} ${props.title}`, `${Delete}`)}>Delete</Button>
                    </section>
                </>} />
            
        </article>
    )
}