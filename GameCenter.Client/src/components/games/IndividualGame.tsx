import { GameDTO } from "./interface/games.model";
import css from "./css/IndividualGame.module.css";

export const IndividualGame = (props: GameDTO) => {
    const buildLink = () => `/game/${props.id}`
    return (
        <div className={css.game}>
            <a href={buildLink()}>
                <img alt="Poster" src={props.poster}/>
            </a>
            <p>
                <a href={buildLink()}>{props.title}</a>
            </p>
        </div>
    )
}