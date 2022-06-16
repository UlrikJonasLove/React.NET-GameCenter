import { actorCreationDTO } from "../components/actors/model/actorsDTOs.model";
import { GameCreationDto } from "../components/games/models/games.model";

export const convertActorToFormData = (actor: actorCreationDTO): FormData => {
    const formData = new FormData();

    formData.append("name", actor.name);

    if(actor.biography)
    {
        formData.append("biography", actor.biography);
    }

    if(actor.dateOfBirth) {
        formData.append("dateOfBirth", formatDate(actor.dateOfBirth));
    }

    if(actor.picture){
        formData.append("picture", actor.picture);
    }


    return formData;
}

export const convertGameToFormData = (game: GameCreationDto) => {
    const formData = new FormData();

    formData.append("title", game.title);

    if(game.summary){
        formData.append("summary", game.summary);
    }

    formData.append("trailer", game.trailer);
    formData.append("newlyReleased", String(game.newlyReleased));

    if(game.releaseDate) {
        formData.append("releaseDate", formatDate(game.releaseDate));
    }

    if(game.poster){
        formData.append("poster", game.poster);
    }

    formData.append("genreIds", JSON.stringify(game.genreIds));
    formData.append("gameCenterIds", JSON.stringify(game.gameCenterIds));
    formData.append("actors", JSON.stringify(game.actors));

    return formData;
}


const formatDate = (date: Date) => {
    date = new Date(date);

    const format = new Intl.DateTimeFormat("en", {
        year: "numeric",
        month: "2-digit",
        day: "2-digit"
    });

    const [
        { value: month },, 
        { value: day },, 
        { value: year }] = format.formatToParts(date);

        return `${year}/${month}/${day}`;
}