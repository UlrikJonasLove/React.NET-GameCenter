import { actorGameDto } from "../../actors/model/actorsDTOs.model";
import { genreDTO } from "../../genres/models/Genres.model";
import { gameCenterDTO } from "../../gamecenters/models/GameCenterDTO.model";

export interface GameDto {
    id: number;
    title: string;
    poster: string;
    newlyReleased: boolean;
    trailer: string;
    summary?: string;
    releaseDate: Date;
    genres: genreDTO[];
    gameCenters: numgameCenterDTOber[];
    actors: actorGameDto[];
}

export interface LandingPageDto {
    newlyReleases?: GameDTO[];
    upcomingReleases?: GameDTO[];
}

export interface GameCreationDto {
    title: string;
    newlyReleased: boolean;
    trailer: string;
    summary?: string;
    releaseDate?: Date;
    poster?: File;
    posterUrl?: string;
    genresIds?: number[];
    gameCentersIds?: number[];
    actors?: actorGameDto[];
}

export interface filterGamesFormDto {
    title: string;
    genreId: number;
    upcomingReleases: boolean;
    newlyReleases: boolean;
}

export interface gamesPostGetDto {
    genres: genreDTO[];
    gameCenters: gameCenterDTO[];
}

export interface gamePutGetDto {
    game: GameDto;
    selectedGenres: genreDTO[];
    nonSelectedGenres: genreDTO[];
    SelectedGameCenters: gameCenterDTO[];
    nonSelectedGameCenters: gameCenterDTO[];
    actors: actorGameDto[];
}