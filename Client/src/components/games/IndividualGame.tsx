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
                <img alt="Poster" src={props.poster}/>
            </Link>
            <p>
                <Link to={buildLink()}>{props.title}</Link>
            </p>
            <section>
                <Link style={{marginRight: '1rem'}} className="btn btn-info" to={`/game/edit/${props.id}`}>Edit</Link>
                <Button onClick={() => customConfirm(() => onDelete(), `${Delete} ${props.title}`, `${Delete}`)}>Delete</Button>
            </section>
        </article>
    )
}