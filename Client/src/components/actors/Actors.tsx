import { Link } from "react-router-dom"

export const Actors = () => {
    document.title = "Game Center - Actors"
    return(
        <>
            <h3>Actors</h3>
            <Link className="btn btn-primary" to="/actors/create">Create Actor</Link>
        </>
    )
}