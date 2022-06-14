import { GameDto } from "./models/games.model";
import css from "./css/IndividualGame.module.css";
import { Link } from "react-router-dom";

export const IndividualGame = (props: GameDto) => {
    const buildLink = () => `/game/${props.id}`
    return (
        <div className={css.game}>
            <Link to={buildLink()}>
                <img alt="Poster" src={props.poster}/>
            </Link>
            <p>
                <Link to={buildLink()}>{props.title}</Link>
            </p>
        </div>
    )
}