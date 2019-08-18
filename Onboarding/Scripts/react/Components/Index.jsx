import React from "react"
import ReactDOM from "react-dom"


export default class Start extends React.Component {

    render() {
        return (
            <div>
                <h1> Hello</h1>

            </div>
        )
    }
}


ReactDOM.render(<Start />, document.getElementById("root"))