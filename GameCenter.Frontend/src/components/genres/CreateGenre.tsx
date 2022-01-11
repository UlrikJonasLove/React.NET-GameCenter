import GenreForm from './GenreForm'

export default function CreateGenre() {
    // const history = useHistory();
    return(
        <>
            <h3>Create Genre</h3>

            <GenreForm model={{name: ""}} 
            onSubmit={async value => {
                await new Promise(r => setTimeout(r, 1000));
                console.log(value)
            }}/>
        </>
    )
}