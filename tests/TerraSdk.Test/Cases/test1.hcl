input "test" "test1" {
	name = "test"
}

tfm "null" "inout" {
	depends_on = input.test.test1
}

output "test" "test1" {
	depends_on = tfm.null.inout
}

