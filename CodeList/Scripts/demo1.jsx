

var App = React.createClass({
    render: function(){
        return(
            <p>Hello world component</p>
            );
    }

});


ReactDOM.render(<App />, document.getElementById("demo1"));

//================================================================================

var Adder = React.createClass({

    render: function () {

        var num1 = parseInt(this.props.num1);
        var num2 = parseInt(this.props.num2);
        var sum = num1 + num2;

        return (
            <p>The sum of {num1} and {num2} is {sum}</p>
            );
    }
});

ReactDOM.render(<Adder num1="3" num2="2" />, document.getElementById("demo2"));


//================================================================================
// https://scotch.io/tutorials/learning-react-getting-started-and-concepts

var Counter = React.createClass({
    handleClick: function(){
        this.setState({
            count: this.state.count + 1
        });

    },
    getInitialState: function () {
        return {  count:0 };
    },
    render: function () {
        return(
            <div>
                <input type="button" value={this.state.count} onClick={this.handleClick}/>
                
            </div>
        );
    }

});


ReactDOM.render(<Counter />, document.getElementById("demo3"));





//================================================================================
// https://scotch.io/tutorials/learning-react-getting-started-and-concepts


var FilteredList = React.createClass({
    filterList: function(event){
        var updatedList = this.state.initialItems;
        updatedList = updatedList.filter(function(item){
            return item.toLowerCase().search(
              event.target.value.toLowerCase()) !== -1;
        });
        this.setState({items: updatedList});
    },
    getInitialState: function(){
        return {
            initialItems: [
              "Apples",
              "Broccoli",
              "Chicken",
              "Duck",
              "Eggs",
              "Fish",
              "Granola",
              "Hash Browns"
            ],
            items: []
        }
    },
    componentWillMount: function(){
        this.setState({items: this.state.initialItems})
    },
    render: function(){
        return (
          <div className="filter-list">
            <input type="text" placeholder="Search" onChange={this.filterList}/>
          <List items={this.state.items}/>
          </div>
      );
    }
});

var List = React.createClass({
    render: function(){
        return (
          <ul>
          {
              this.props.items.map(function(item) {
                  return <li key={item}>{item}</li>
              })
          }
          </ul>
        )  
    }
});

ReactDOM.render(<FilteredList/>, document.getElementById('demo4'));