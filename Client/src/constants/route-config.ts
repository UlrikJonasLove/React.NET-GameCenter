import { CreateGenre } from "../components/genres/CreateGenre";
import { EditGenre } from "../components/genres/EditGenre";
import { Genres } from "../components/genres/Genres";

import { Actors } from "../components/actors/Actors";
import { CreateActor } from "../components/actors/CreateActor";
import { EditActor } from "../components/actors/EditActor";

import { GameCenters } from "../components/gamecenters/GameCenters";
import { CreateGameCenter } from "../components/gamecenters/CreateGameCenter";
import { EditGameCenter } from "../components/gamecenters/EditGameCenter";

import { LandingPage } from "../components/games/LandingPage";
import { FilterGame } from "../components/games/FilterGame";
import { CreateGame } from "../components/games/CreateGame";
import { EditGame } from "../components/games/EditGame";

import { RedirectToLandingPage } from "../components/utils/RedirectToLandingPage";
import { GameDetails } from "../components/games/GameDetails";

export const routes = [
    {path: "/genres", component: Genres, exact: true},
    {path: "/genres/create", component: CreateGenre},
    {path: "/genres/edit/:id(\\d+)", component: EditGenre},

    {path: "/actors", component: Actors, exact: true},
    {path: "/actors/create", component: CreateActor},
    {path: "/actors/edit/:id(\\d+)", component: EditActor},

    {path: "/gamecenters", component: GameCenters, exact: true},
    {path: "/gamecenters/create", component: CreateGameCenter},
    {path: "/gamecenters/edit/:id(\\d+)", component: EditGameCenter},

    {path: "/games/search", component: FilterGame},
    {path: "/game/create", component: CreateGame},
    {path: "/game/edit/:id(\\d+)", component: EditGame},
    {path: "/game/:id(\\d+)", component: GameDetails},



    {path: "/", component: LandingPage, exact: true},
    {path: "*", component: RedirectToLandingPage}
];